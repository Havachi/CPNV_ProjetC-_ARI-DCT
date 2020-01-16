  using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameLib;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace GameLib
{
    public class MapGenerator
    {
        private Board board;
        private Case nextCase;
        private Position currentPosition;
        Stack<Case> activeCases = new Stack<Case>();


        private string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        //private string projectPath = System.IO.Directory.GetCurrentDirectory();
        private string pathToFixedMap;

        private List<int> directionHistory = new List<int>();

        
        private int width;
        private int height;
        private int nbVisitedCases = 0;

        public MapGenerator(bool randomGeneration)
        {
            board = new Board(10, 10);
            if (randomGeneration)
            {
                board = GenerateMap();
            }
            else
            {
                pathToFixedMap = $@"{projectPath}\TestMap\map1.csv";
                
                board = GenerateFixedMap();
            }
        }
        public MapGenerator(int maxHeight, int maxWidth, bool randomGeneration)
        {
            board = new Board(maxHeight, maxWidth);
            board = randomGeneration ? GenerateMap() : GenerateFixedMap();
        }

        /// <summary>
        /// Generate a map that is always the same
        /// </summary>
        /// <returns>The board of the map</returns>
        public Board GenerateFixedMap()
        {
            Board fixedBoard = new Board(30,30);
            fixedBoard.FromFile(pathToFixedMap);

            return fixedBoard;
        }

        public Board GenerateVoidBoard(int maxWidth, int maxHeight)
        {
            Board voidBoard = new Board(maxHeight,maxWidth);
            BoardLine voidBoardLine = new BoardLine();
            int indexX = 0; 
            int indexY = 0;
            for (int i = 0; i < maxHeight; i++)
            {
                for (int j = 0; j < maxWidth; j++)
                {
                    indexX++;
                    voidBoardLine.AddCase(new VoidCase(indexX,indexY));
                }
                indexX = 0;
                indexY++;
                voidBoard.AddLine(voidBoardLine);
                voidBoardLine = new BoardLine();
            }
            return voidBoard;
        }

        public Board GenerateBorders(Board borderBoard)
           {
            
            int indexX = 0;
            int indexY = 0;
            for (int i = 0; i < borderBoard.Height; i++)
            {
                for (int j = 0; j < borderBoard.Width; j++)
                {
                    if (i == 0 || i == borderBoard.Height-1)
                    {
                        borderBoard.BoardContent[i].LineContent[j] = new WallCase(indexX, indexY);

                    }
                    if (j == 0 || j == borderBoard.Width-1)
                    {
                        borderBoard.BoardContent[i].LineContent[j] = new WallCase(indexX, indexY);

                    }
                    indexX++;
                }
                indexX = 0;
                indexY++;
            }
            return borderBoard;
        }

        /// <summary>
        /// Generate a random map everytime
        /// </summary>
        /// <returns>The board of the map</returns>
        public Board GenerateMap()
        {

            //todo generate borders
            //todo create rules to make the map playable

            

            //Generate an empty board with void case
            board = GenerateVoidBoard(board.Width, board.Height);
            board = GenerateBorders(board);
            //Choose a random Starting point
            Random random = new Random();



            Position startPosition;
            do
            {
                int randX = random.Next(board.Width);
                int randY = random.Next(board.Height);
                startPosition = new Position(randX,randY);
            } while (board.BoardContent[startPosition.PositionY].LineContent[startPosition.PositionX].GetType() != typeof(VoidCase));
            
            currentPosition = startPosition;

            
            board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX] = new StartCase(currentPosition.PositionX,currentPosition.PositionY,1);
            activeCases.Push(board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX]);
            int nbUnvisitedCases = board.Count();
            while (nbVisitedCases < board.Width * board.Height)
            {
                MoveAndChange();
            }
            board.BoardContent[activeCases.Last().IndexY].LineContent[activeCases.Last().IndexX] = new EndCase(activeCases.Last().IndexX, activeCases.Last().IndexY,1);
            return board;
        }

        public void MoveAndChange()
        {
            var currentCase = board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX];
            var futureDirection = GetFutureDirection();

            //currentCase = OpenCurrentCase(futureDirection);
            //board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX] = currentCase;

            switch (futureDirection)
            {
                case 0:
                    activeCases.Pop();
                    if (activeCases.Count != 0)
                    {
                        currentPosition.PositionX = activeCases.First().IndexX;
                        currentPosition.PositionY = activeCases.First().IndexY;
                    }
                    break;
                //Case Up
                case 1:
                    currentPosition.PositionY--;
                    ChangeCaseWalls(currentCase, futureDirection);
                    currentCase = ChangeCaseType();
                    activeCases.Push(currentCase);
                    nbVisitedCases++;

                    break;
                //Case Right
                case 2:
                    currentPosition.PositionX++;
                    ChangeCaseWalls(currentCase, futureDirection);
                    currentCase = ChangeCaseType();
                    activeCases.Push(currentCase);
                    nbVisitedCases++;

                    break;
                //Case Down
                case 3:
                    currentPosition.PositionY++;
                    ChangeCaseWalls(currentCase, futureDirection);
                    currentCase = ChangeCaseType();
                    activeCases.Push(currentCase);
                    nbVisitedCases++;

                    break;
                //case left
                case 4:
                    currentPosition.PositionX--;
                    ChangeCaseWalls(currentCase, futureDirection);
                    currentCase = ChangeCaseType();
                    activeCases.Push(currentCase);
                    nbVisitedCases++;

                    break;
            }
        }
        public void ChangeCaseWalls(Case currentCase, int futureDirection)
        {
            if (currentCase.GetType() == typeof(StartCase))
            {
                currentCase.Walls[0] = false;
                currentCase.Walls[1] = false;
                currentCase.Walls[2] = false;
                currentCase.Walls[3] = false;
                return;
            }
            if (directionHistory.Count<=1)
            {
                switch (futureDirection)
                {
                    case 1:
                        currentCase.Walls[0] = false;
                        currentCase.Walls[1] = true;
                        currentCase.Walls[2] = true;
                        currentCase.Walls[3] = true;
                        break;
                    case 2:
                        currentCase.Walls[0] = true;
                        currentCase.Walls[1] = false;
                        currentCase.Walls[2] = true;
                        currentCase.Walls[3] = true;
                        break;
                    case 3:
                        currentCase.Walls[0] = true;
                        currentCase.Walls[1] = true;
                        currentCase.Walls[2] = false;
                        currentCase.Walls[3] = true;
                        break;
                    case 4:
                        currentCase.Walls[0] = true;
                        currentCase.Walls[1] = true;
                        currentCase.Walls[2] = true;
                        currentCase.Walls[3] = false;
                        break;
                }
                
            }
            else
            {
                switch (futureDirection)
                {
                    //UP
                    case 1:
                        currentCase.Walls[0] = false;
                        //UP
                        if (directionHistory[directionHistory.Count-2] == 1)
                        {
                            currentCase.Walls[1] = true;
                            currentCase.Walls[2] = false;
                            currentCase.Walls[3] = true;
                        }
                        //Right
                        else if (directionHistory[directionHistory.Count - 2] == 2)
                        {
                            currentCase.Walls[1] = true;
                            currentCase.Walls[2] = true;
                            currentCase.Walls[3] = false;
                        }
                        //Left
                        else if (directionHistory[directionHistory.Count - 2] == 4)
                        {
                            currentCase.Walls[1] = false;
                            currentCase.Walls[2] = true;
                            currentCase.Walls[3] = true;
                        }
                        break;
                    //Right
                    case 2:
                        currentCase.Walls[1] = false;
                        //Up
                        if (directionHistory[directionHistory.Count - 2] == 1)
                        {
                            currentCase.Walls[0] = true;
                            currentCase.Walls[2] = false;
                            currentCase.Walls[3] = true;
                        }
                        //Right
                        else if (directionHistory[directionHistory.Count - 2] == 2)
                        {
                            currentCase.Walls[0] = true;
                            currentCase.Walls[2] = true;
                            currentCase.Walls[3] = false;
                        }
                        //Down
                        else if (directionHistory[directionHistory.Count - 2] == 3)
                        {
                            currentCase.Walls[0] = false;
                            currentCase.Walls[2] = true;
                            currentCase.Walls[3] = true;
                        }
                        break;
                    //Down
                    case 3:
                        //Right
                        if (directionHistory[directionHistory.Count - 2] == 2)
                        {
                            currentCase.Walls[0] = true;
                            currentCase.Walls[1] = true;
                            currentCase.Walls[2] = false;
                            currentCase.Walls[3] = false;
                        }
                        //Down
                        else if (directionHistory[directionHistory.Count - 2] == 3)
                        {
                            currentCase.Walls[0] = false;
                            currentCase.Walls[1] = true;
                            currentCase.Walls[2] = false;
                            currentCase.Walls[3] = true;
                        }
                        //Left
                        else if (directionHistory[directionHistory.Count - 2] == 4)
                        {
                            currentCase.Walls[0] = true;
                            currentCase.Walls[1] = false;
                            currentCase.Walls[2] = false;
                            currentCase.Walls[3] = true;
                        }
                        break;
                    //Left
                    case 4:
                        //UP
                        if (directionHistory[directionHistory.Count - 2] == 1)
                        {
                            currentCase.Walls[0] = true;
                            currentCase.Walls[1] = true;
                            currentCase.Walls[2] = false;
                            currentCase.Walls[3] = false;
                        }
                        //Down
                        else if (directionHistory[directionHistory.Count - 2] == 3)
                        {
                            currentCase.Walls[0] = false;
                            currentCase.Walls[1] = true;
                            currentCase.Walls[2] = true;
                            currentCase.Walls[3] = false;
                        }
                        //Left
                        else if (directionHistory[directionHistory.Count - 2] == 4)
                        {
                            currentCase.Walls[0] = true;
                            currentCase.Walls[1] = false;
                            currentCase.Walls[2] = true;
                            currentCase.Walls[3] = false;
                        }
                        break;
                }
            }
        }

        public int GetFutureDirection()
        {
            List<int> possibleMove = new List<int>();
            Random random = new Random();

            //if (directionHistory.Count == 0)
            //{
                if (CanGoUp())
                {
                    possibleMove.Add(1);
                }
                if (CanGoRight())
                {
                    possibleMove.Add(2);
                }
                if (CanGoDown())
                {
                    possibleMove.Add(3);
                }
                if (CanGoLeft())
                {
                    possibleMove.Add(4);
                }
            // }
            //else
            //{
            /*
                if (CanGoUp())
                {
                    if (directionHistory.Last() != 1)
                    {
                        possibleMove.Add(1);
                    }

                }
                if (CanGoRight())
                {
                    if (directionHistory.Last() != 2)
                    {
                        possibleMove.Add(2);
                    }
                }
                if (CanGoDown())
                {
                    if (directionHistory.Last() != 3)
                    {
                        possibleMove.Add(3);
                    }
                }
                if (CanGoLeft())
                {
                    if (directionHistory.Last() != 4)
                    {
                        possibleMove.Add(4);
                    }
                }
                */
            //}
            if (possibleMove.Count == 0)
            {
                return 0;
            }
            int r = random.Next(possibleMove.Count);
            directionHistory.Add(possibleMove[r]);
            return possibleMove[r];
        }

        /// <summary>
        /// This method return the orientation that a case should be 
        /// </summary>
        /// <param name="currentCase"></param>
        /// <param name="direction"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public int GetFutureOrientation(Case currentCase, int direction,int destinationType)
        {
            var futureOrientation = 0;

            if (direction == 1)
            {
                futureOrientation = 1;
            }

            if (direction==2)
            {
                if (currentCase.GetType() == typeof(CrosswayCase))
                {
                    futureOrientation = 1;
                }
                else
                {
                    futureOrientation = 2;
                }
            }

            if (direction == 3)
            {
                if (currentCase.GetType() == typeof(CrosswayCase))
                {
                    futureOrientation = 1;
                }
                else if (currentCase.GetType() == typeof(CorridorCase))
                {
                    futureOrientation = 2;
                }
                else
                {
                    futureOrientation = 3;
                }
            }

            if (direction == 4)
            {
                if (currentCase.GetType() == typeof(CrosswayCase) || currentCase.GetType() == typeof(CorridorCase))
                {
                    futureOrientation = 1;
                }
                else
                {
                    futureOrientation = 4;
                }
            }
            return futureOrientation;
        }

        /// <summary>
        /// This method return the type of case that a case should be
        /// </summary>
        /// <param name="currentCase"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public int GetDestinationType(Case currentCase, int direction)
        {
            var destinationType = 0;
            var futureVisitedCases = VisitedFutureNeighboursCases(direction);
            var openWalls = new bool[4];
            var nbOpenWalls = 0;

            if (futureVisitedCases.Count == 0)
            {
                destinationType = 2;
            }
            else
            {
                if (direction == 1)
                {
                    if (futureVisitedCases[0].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[1].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[2].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[3].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                }
                else if (direction == 2)
                {
                    if (futureVisitedCases[0].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[1].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[2].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[3].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                }
                else if (direction == 3)
                {
                    if (futureVisitedCases[0].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[1].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[2].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[3].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                }
                else if (direction == 4)
                {
                    if (futureVisitedCases[0].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[1].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[2].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                    if (futureVisitedCases[3].GetType() == typeof(VoidCase))
                    {
                        openWalls[0] = false;
                    }
                }
            }

            if (openWalls[0])
            {
                if (futureVisitedCases[0].GetType() == typeof(CornerCase))
                {
                    if (futureVisitedCases[0].Orientation != 1 || futureVisitedCases[0].Orientation != 2)
                    {
                        openWalls[0] = false;
                    }
                }
                else if (futureVisitedCases[0].GetType() == typeof(DeadEnd) && futureVisitedCases[0].Orientation != 1)
                {
                    openWalls[0] = false;
                }
                else if (futureVisitedCases[0].GetType() == typeof(CorridorCase) && futureVisitedCases[0].Orientation != 1)
                {
                    openWalls[0] = false;
                }
                else if (futureVisitedCases[0].GetType() == typeof(TShapeCase) && futureVisitedCases[0].Orientation == 3)
                {
                    openWalls[0] = false;
                }
            }
            if (openWalls[1])
            {
                if (futureVisitedCases[1].GetType() == typeof(CornerCase))
                {
                    if (futureVisitedCases[1].Orientation != 2 || futureVisitedCases[1].Orientation != 3)
                    {
                        openWalls[1] = false;
                    }
                }
                else if (futureVisitedCases[1].GetType() == typeof(DeadEnd) && futureVisitedCases[1].Orientation != 2)
                {
                    openWalls[1] = false;
                }
                else if (futureVisitedCases[1].GetType() == typeof(CorridorCase) && futureVisitedCases[1].Orientation != 2)
                {
                    openWalls[1] = false;
                }
                else if (futureVisitedCases[1].GetType() == typeof(TShapeCase) && futureVisitedCases[1].Orientation == 4)
                {
                    openWalls[1] = false;
                }
            }
            if (openWalls[2])
            {
                if (futureVisitedCases[2].GetType() == typeof(CornerCase))
                {
                    if (futureVisitedCases[2].Orientation != 3 || futureVisitedCases[2].Orientation != 4)
                    {
                        openWalls[2] = false;
                    }
                }
                else if (futureVisitedCases[2].GetType() == typeof(DeadEnd) && futureVisitedCases[2].Orientation != 3)
                {
                    openWalls[2] = false;
                }
                else if (futureVisitedCases[2].GetType() == typeof(CorridorCase) && futureVisitedCases[2].Orientation != 1)
                {
                    openWalls[2] = false;
                }
                else if (futureVisitedCases[2].GetType() == typeof(TShapeCase) && futureVisitedCases[2].Orientation == 1)
                {
                    openWalls[2] = false;
                }
            }
            if (openWalls[3])
            {
                if (futureVisitedCases[3].GetType() == typeof(CornerCase))
                {
                    if (futureVisitedCases[3].Orientation != 1 || futureVisitedCases[3].Orientation != 4)
                    {
                        openWalls[3] = false;
                    }
                }
                else if (futureVisitedCases[3].GetType() == typeof(DeadEnd) && futureVisitedCases[3].Orientation != 4)
                {
                    openWalls[3] = false;
                }
                else if (futureVisitedCases[3].GetType() == typeof(CorridorCase) && futureVisitedCases[3].Orientation != 2)
                {
                    openWalls[3] = false;
                }
                else if (futureVisitedCases[3].GetType() == typeof(TShapeCase) && futureVisitedCases[3].Orientation == 2)
                {
                    openWalls[3] = false;
                }
            }

            foreach (var wall in openWalls)
            {
                if (wall)
                {
                    nbOpenWalls++;
                }
            }

            if (nbOpenWalls == 1)
            {
                destinationType = 1;
            }

            if (nbOpenWalls == 2)
            {
                if ((openWalls[0] && openWalls[2]) ||(openWalls[1] && openWalls[4]))
                {
                    destinationType = 4;
                }
                else
                {
                    destinationType = 1;
                }
            }
            if (nbOpenWalls == 3)
            {
                destinationType = 5;
            }
            if (nbOpenWalls == 4)
            {
                destinationType = 3;
            }

            if (destinationType == 0)
            {
                return 2;
            }
            
            return destinationType;
        }


        #region Generator Methods

        #region Path Management



        #endregion

        #region Case Management


        /// <summary>
        /// Represent the actual case
        /// </summary>
        /// <returns></returns>
        public Case Self()
        {
            return board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX];
        }
        
        /// <summary>
        /// Represent the case that is on top of the current case
        /// </summary>
        /// <returns></returns>
        public Case TopCase()
        {
            if (currentPosition.PositionY != 0)
            {
                return board.BoardContent[currentPosition.PositionY-1].LineContent[currentPosition.PositionX];
            }
            else
            {
                return null;
            }
        }
        public Case TopCase(int indexX, int indexY)
        {
            if (indexY != 0)
            {
                return board.BoardContent[indexY - 1].LineContent[indexX];
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Represent the case that is on the right of the current case
        /// </summary>
        /// <returns></returns>
        public Case RightCase()
        {
            if (currentPosition.PositionX < board.Width-1)
            {
                return board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX+1];
            }
            else
            {
                return null;
            }
        }
        public Case RightCase(int indexX, int indexY)
        {
            if (indexX < board.Width - 1)
            {
                return board.BoardContent[indexY].LineContent[indexX + 1];
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Represent the case that is under the current case
        /// </summary>
        /// <returns></returns>
        public Case BottomCase()
        {
            if (currentPosition.PositionY < board.Height-1)
            {
                return board.BoardContent[currentPosition.PositionY + 1].LineContent[currentPosition.PositionX];
            }
            else
            {
                return null;
            }
        }
        public Case BottomCase(int indexX, int indexY)
        {
            if (indexY < board.Height -1)
            {
                return board.BoardContent[indexY + 1].LineContent[indexX];
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Represent the case that is on the left of the current case
        /// </summary>
        /// <returns></returns>
        public Case LeftCase()
        {
            if (currentPosition.PositionX != 0)
            {
                return board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX-1];
            }
            else
            {
                return null;
            }
        }
        public Case LeftCase(int indexX,int indexY)
        {
            if (indexX != 0)
            {
                return board.BoardContent[indexY].LineContent[indexX - 1];
            }
            else
            {
                return null;
            }
        }
       
        /// <summary>
        /// This method return all the unvisited cases around the future case
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<Case> UnvisitedFutureNeighboursCases(int direction)
        {
            List<Case> unvisitedCases=new List<Case>();
            var posX = 0;
            var posY = 0;
            if (direction == 1)
            {
                posX = TopCase().IndexX;
                posY = TopCase().IndexY;
            }
            else if (direction == 2)
            {
                posX = RightCase().IndexX;
                posY = RightCase().IndexY;

            }
            else if (direction == 3)
            {
                posX = BottomCase().IndexX;
                posY = BottomCase().IndexY;
            }
            else if (direction == 4)
            {
                posX = LeftCase().IndexX;
                posY = LeftCase().IndexY;
            }

            if (TopCase(posX,posY).GetType() == typeof(VoidCase) && direction != 3)
            {
                unvisitedCases.Add(TopCase(posX, posY));
            }

            if (RightCase(posX, posY).GetType() == typeof(VoidCase) && direction != 4)
            {
                unvisitedCases.Add(RightCase(posX, posY));
            }

            if (BottomCase(posX, posY).GetType() == typeof(VoidCase) && direction != 1)
            {
                unvisitedCases.Add(BottomCase(posX, posY));
            }

            if (LeftCase(posX, posY).GetType() == typeof(VoidCase) && direction != 2)
            {
                unvisitedCases.Add(LeftCase(posX, posY));
            }

            return unvisitedCases;
        }
        /// <summary>
        /// This method return all the visited cases around the future case
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<Case> VisitedFutureNeighboursCases(int direction)
        {
            List<Case> visitedCases = new List<Case>();
            var posX = 0;
            var posY = 0;
            if (direction == 1)
            {
                posX = TopCase().IndexX;
                posY = TopCase().IndexY;
            }
            else if (direction == 2)
            {
                posX = RightCase().IndexX;
                posY = RightCase().IndexY;

            }
            else if (direction == 3)
            {
                posX = BottomCase().IndexX;
                posY = BottomCase().IndexY;
            }
            else if (direction == 4)
            {
                posX = LeftCase().IndexX;
                posY = LeftCase().IndexY;
            }

            if ((posX > 0 && posY > 0) && (posX < board.Width && posY < board.Width))
            {
                if (TopCase(posX,posY) != null)
                {
                    if (TopCase(posX, posY).GetType() != typeof(VoidCase) && direction != 3)
                    {
                        visitedCases.Add(TopCase(posX, posY));
                    }
                    else
                    {
                        visitedCases.Add(new VoidCase(posX, posY));
                    }
                }
                else
                {
                    visitedCases.Add(new VoidCase(posX, posY));
                }
                if (RightCase(posX,posY) !=null)
                {
                    if (RightCase(posX, posY).GetType() != typeof(VoidCase) && direction != 4)
                    {
                        visitedCases.Add(RightCase(posX, posY));
                    }
                    else
                    {
                        visitedCases.Add(new VoidCase(posX, posY));
                    }
                }
                else
                {
                    visitedCases.Add(new VoidCase(posX, posY));
                }
                if (BottomCase(posX,posY) != null)
                {
                    if (BottomCase(posX, posY).GetType() != typeof(VoidCase) && direction != 1)
                    {
                        visitedCases.Add(BottomCase(posX, posY));
                    }
                    else
                    {
                        visitedCases.Add(new VoidCase(posX, posY));
                    }
                }
                else
                {
                    visitedCases.Add(new VoidCase(posX, posY));
                }
                if (LeftCase(posX,posY) != null)
                {
                    if (LeftCase(posX, posY).GetType() != typeof(VoidCase) && direction != 2)
                    {
                        visitedCases.Add(LeftCase(posX, posY));
                    }
                    else
                    {
                        visitedCases.Add(new VoidCase(posX, posY));
                    }
                }
                else
                {
                    visitedCases.Add(new VoidCase(posX, posY));
                }
            }
            return visitedCases;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexX"></param>
        /// <param name="indexY"></param>
        /// <param name="orientation"></param>
        /// <param name="destinationType">1 = Corner, 2 = DeadEnd, 3 = Crossway, 4 = Corridor, 5 = T-Shaped</param>
        public Case ChangeCaseType()
        {
            var currentCase = board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX];
            int counter = 0;
            foreach (var wall in currentCase.Walls)
            {
                if (wall)
                {
                    counter++;
                }
            }

            switch (counter)
            {
                case 0:
                    currentCase = new CrosswayCase(currentCase.IndexX,currentCase.IndexY,1);
                    break;
                case 1:
                    if (currentCase.Walls[0])
                    {
                        currentCase = new TShapeCase(currentCase.IndexX, currentCase.IndexY,1);
                    }
                    else if (currentCase.Walls[1])
                    {
                        currentCase = new TShapeCase(currentCase.IndexX, currentCase.IndexY, 2);
                    }
                    else if (currentCase.Walls[2])
                    {
                        currentCase = new TShapeCase(currentCase.IndexX, currentCase.IndexY, 3);
                    }
                    else if (currentCase.Walls[3])
                    {
                        currentCase = new TShapeCase(currentCase.IndexX, currentCase.IndexY, 4);
                    }
                    break;
                case 2:
                    if (currentCase.Walls[0])
                    {
                        if (currentCase.Walls[1])
                        {
                           currentCase = new CornerCase(currentCase.IndexX, currentCase.IndexY,2); 
                        }
                        if (currentCase.Walls[2])
                        {
                            currentCase = new CorridorCase(currentCase.IndexX, currentCase.IndexY,2);
                        }
                        if (currentCase.Walls[3])
                        {
                            currentCase = new CornerCase(currentCase.IndexX, currentCase.IndexY, 1);
                        }
                    }

                    else if (currentCase.Walls[2])
                    {
                        if (currentCase.Walls[1])
                        {
                            currentCase = new CornerCase(currentCase.IndexX, currentCase.IndexY, 3);
                        }
                        else if (currentCase.Walls[3])
                        {
                            currentCase = new CornerCase(currentCase.IndexX, currentCase.IndexY, 4);
                        }
                    }
                    else
                    {
                        currentCase = new CorridorCase(currentCase.IndexX, currentCase.IndexY, 1);
                    }
                    break;
                case 3:
                    int orientation = 0;
                    if (!currentCase.Walls[0])
                    {
                        orientation = 3;
                    }
                    if (!currentCase.Walls[1])
                    {
                        orientation = 4;
                    }
                    if (!currentCase.Walls[2])
                    {
                        orientation = 1;
                    }
                    if (!currentCase.Walls[3])
                    {
                        orientation = 2;
                    }
                    currentCase = new DeadEnd(currentCase.IndexX,currentCase.IndexY,orientation);
                    break;
                default:
                    currentCase = new CrosswayCase(currentCase.IndexX, currentCase.IndexY, 1);
                    break;
            }

            return currentCase;

        }

        public Case SearchInBoard(int indexX, int indexY)
        {
            return board.BoardContent[indexY].LineContent[indexX];
        }

        public Case OpenCurrentCase(int direction)
        {
            var currentCase = Self();
            var x = currentPosition.PositionX;
            var y = currentPosition.PositionY;

            switch (currentCase.TypeToInt())
            {
                case 1:
                    switch (currentCase.Orientation)
                    {
                        case 1:
                            if (direction == 1)
                            {
                                currentCase = new TShapeCase(x,y,4);
                            }
                            else if (direction == 4)
                            {
                                currentCase = new TShapeCase(x, y,1);
                            }
                            break;
                        case 2:
                            if (direction == 1)
                            {
                                currentCase = new TShapeCase(x, y, 2);
                            }
                            else if (direction == 2)
                            {
                                currentCase = new TShapeCase(x,y, 1);
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (currentCase.Orientation)
                    {
                        case 1:
                            if (direction == 1)
                            {
                                currentCase = new CorridorCase(x, y, 1);
                            }
                            else if (direction == 2)
                            {
                                currentCase = new CornerCase(x, y, 1);
                            }
                            else if (direction == 4)
                            {
                                currentCase = new CornerCase(x, y, 2);
                            }
                            break;
                        case 2:
                            if (direction == 1)
                            {
                                currentCase = new CornerCase(x,y, 3);
                            }
                            else if (direction == 2)
                            {
                                currentCase = new CorridorCase(x,y,2);
                            }
                            else if (direction == 3)
                            {
                                currentCase = new CornerCase(x,y,2);
                            }
                            break;
                        case 4:
                            if (direction == 1)
                            {
                                currentCase = new CornerCase(x,y,3);
                            }
                            else if (direction == 3)
                            {
                                currentCase = new CornerCase(x,y,1);
                            }
                            else if (direction == 4)
                            {
                                currentCase = new CorridorCase(x,y,2);
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (currentCase.Orientation)
                    {
                        case 1:
                            if (direction == 2 )
                            {
                                currentCase = new TShapeCase(x,y,2);
                            }
                            else if (direction == 4)
                            {
                                currentCase = new TShapeCase(x, y, 4);
                            }
                            break;
                        case 2:
                            if (direction == 1)
                            {
                                currentCase = new TShapeCase(x, y, 3);
                            }
                            else if (direction == 3)
                            {
                                currentCase = new TShapeCase(x, y, 1);
                            }
                            break;

                    }
                    break;
                case 5:
                    currentCase = new CrosswayCase(x,y,1);
                    break;
            }

            return currentCase;
        }
        #endregion

        #region Generation Rules Method

        /// <summary>
        /// This method check if it's possible to go up.
        /// </summary>
        /// <returns></returns>
        public bool CanGoUp()
        {

            
            //Check if the top case is null
            if (TopCase() == null) return false;
            //Check if the case on top is a wall
            if (TopCase().GetType() == typeof(WallCase)) return false;

            //Check if the current position is equal to 0, that represent the top great border
            if (currentPosition.PositionY < 1) return false;
            //Check if there is something in the direction history
            if (directionHistory.Any())
            {
                //Then check if the last move was down
                if (directionHistory.Last() == 3)
                {
                    return false;
                }
            }
            //Check if the actual case if a dead end
            if (Self().GetType() == typeof(DeadEnd))
            {
                //check if the orientation is equal to 3, that represent a possible move 
                if (Self().Orientation != 3)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CornerCase))
            {
                if (Self().Orientation == 1 || Self().Orientation == 2)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CorridorCase))
            {
                if (Self().Orientation != 1 )
                {
                    return false;
                }
            }

            if (Self().GetType() == typeof(TShapeCase))
            {
                if (Self().Orientation == 1)
                {
                    return false;
                }
            }

            //Check if the top case is empty
            if (TopCase().GetType() == typeof(VoidCase))
            {
                return true;
            }
            //check if the top case is a corner with 1 or 2 as orientation
            if (TopCase().GetType() == typeof(CornerCase) && (TopCase().Orientation == 1 || TopCase().Orientation == 2))
            {
                return true;
            }
            //Check if the top case is a dead end
            if (TopCase().GetType() == typeof(DeadEnd) && TopCase().Orientation == 1 )
            {
                return true;
            }

            if (TopCase().GetType() == typeof(CrosswayCase) && TopCase().Orientation == 1 )
            {
                return true;
            }

            if (TopCase().GetType() == typeof(CorridorCase) && TopCase().Orientation == 1)
            {
                return true;
            }

            if (TopCase().GetType() == typeof(TShapeCase) && (TopCase().Orientation == 1 || TopCase().Orientation == 2 || TopCase().Orientation == 4))
            {
                return true;
            }

            return false;
        }
        public bool CanGoRight()
        {
            if (RightCase() == null) return false;
            if (RightCase().GetType() == typeof(WallCase)) return false;
            if (currentPosition.PositionX >= board.Width - 1) return false;
            if (Self().GetType() == typeof(DeadEnd) && (Self().Orientation != 4)) return false;
            if (directionHistory.Any())
            {
                if (directionHistory.Last() == 4)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CornerCase))
            {
                if (Self().Orientation == 2 || Self().Orientation == 3)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CorridorCase))
            {
                if (Self().Orientation != 2)
                {
                    return false;
                }
            }

            if (Self().GetType() == typeof(TShapeCase))
            {
                if (Self().Orientation == 2)
                {
                    return false;
                }
            }
            if (RightCase().GetType() == typeof(VoidCase))
            {
                return true;
            }

            if (RightCase().GetType() == typeof(CornerCase) && (RightCase().Orientation == 2 || RightCase().Orientation == 3))
            {
                return true;
            }

            if (RightCase().GetType() == typeof(DeadEnd) && RightCase().Orientation == 2)
            {
                return true;
            }

            if (RightCase().GetType() == typeof(CrosswayCase) && RightCase().Orientation == 1)
            {
                return true;
            }

            if (RightCase().GetType() == typeof(CorridorCase) && RightCase().Orientation == 2)
            {
                return true;
            }

            if (RightCase().GetType() == typeof(TShapeCase) && (RightCase().Orientation == 1 || RightCase().Orientation == 2 || RightCase().Orientation == 3))
            {
                return true;
            }

            return false;
        }
        public bool CanGoDown()
        {
            if (BottomCase() == null) return false;
            if (BottomCase().GetType() == typeof(WallCase)) return false;
            if (currentPosition.PositionY >= board.Height - 1) return false;
            if (Self().GetType() == typeof(DeadEnd) && (Self().Orientation != 1)) return false;
            if (directionHistory.Any())
            {
                if (directionHistory.Last() == 1)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CornerCase))
            {
                if (Self().Orientation == 3 || Self().Orientation == 4)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CorridorCase))
            {
                if (Self().Orientation != 1)
                {
                    return false;
                }
            }

            if (Self().GetType() == typeof(TShapeCase))
            {
                if (Self().Orientation == 3)
                {
                    return false;
                }
            }
            if (BottomCase().GetType() == typeof(VoidCase))
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(CornerCase) &&(BottomCase().Orientation == 3 || BottomCase().Orientation == 4))
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(DeadEnd) && BottomCase().Orientation == 3 )
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(CrosswayCase) && BottomCase().Orientation == 1)
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(CorridorCase) && BottomCase().Orientation == 1)
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(TShapeCase) && BottomCase().Orientation != 1)
            {
                return true;
            }
            return false;
        }
        public bool CanGoLeft()
        {
            
            if (BottomCase() == null) return false;
            if (BottomCase().GetType() == typeof(WallCase)) return false;
            if (currentPosition.PositionX < 1) return false;
            if (Self().GetType() == typeof(DeadEnd) && (Self().Orientation != 2)) return false;
            if (directionHistory.Any())
            {
                if (directionHistory.Last() == 2)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CornerCase))
            {
                if (Self().Orientation == 1 || Self().Orientation == 4)
                {
                    return false;
                }
            }
            if (Self().GetType() == typeof(CorridorCase))
            {
                if (Self().Orientation != 2)
                {
                    return false;
                }
            }

            if (Self().GetType() == typeof(TShapeCase))
            {
                if (Self().Orientation == 4)
                {
                    return false;
                }
            }
            if (BottomCase().GetType() == typeof(VoidCase))
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(CornerCase) && (BottomCase().Orientation == 1 || BottomCase().Orientation == 4))
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(DeadEnd) && BottomCase().Orientation == 4)
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(CrosswayCase) && BottomCase().Orientation == 1)
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(CorridorCase) && BottomCase().Orientation == 2)
            {
                return true;
            }

            if (BottomCase().GetType() == typeof(TShapeCase) && BottomCase().Orientation != 2)
            {

            }

            return false;
        }

        #endregion
       
        
        #endregion


        #region Accessors

        public Board Board
        {
            get { return board; }
        }

        #endregion

    }
}
