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

        private List<int> directionHistory = new List<int>();

        private int width;
        private int height;

        public MapGenerator(bool randomGeneration)
        {
            board = new Board(10, 10);
            if (randomGeneration)
            {
                board = GenerateMap();
            }
            else
            {
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
            Board fixedBoard = new Board(50,50);

            fixedBoard = GenerateVoidBoard(fixedBoard.Width,fixedBoard.Height);
            fixedBoard = GenerateBorders(fixedBoard);
            

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

            int nbVisitedCases = 0;

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
            } while (board.BoardContent[startPosition.PositionY].LineContent[startPosition.PositionX].GetType() == typeof(WallCase));
            
            currentPosition = startPosition;

            Stack<Case> activeCases = new Stack<Case>();
            board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX] = new StartCase(currentPosition.PositionX,currentPosition.PositionY,1);
            activeCases.Push(board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX]);

            while (activeCases.Count > 0 || nbVisitedCases == board.Height * board.Width)
            {
                var currentCase = board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX];
                var futureDirection = GetFutureDirection();
                var destinationType = GetDestinationType(currentCase,futureDirection);
                var futureOrientation = GetFutureOrientation(currentCase,futureDirection,destinationType);

                currentCase = OpenCurrentCase(futureDirection);
                board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX] = currentCase;

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
                    case 1:
                        currentPosition.PositionY--;
                        ChangeCaseType(currentPosition.PositionX, currentPosition.PositionY, futureOrientation, destinationType);
                        activeCases.Push(currentCase);
                        nbVisitedCases++;
                        break;
                    case 2:
                        currentPosition.PositionX++;
                        ChangeCaseType(currentPosition.PositionX, currentPosition.PositionY, futureOrientation, destinationType);
                        activeCases.Push(currentCase);
                        nbVisitedCases++;
                        break;
                    case 3:
                        currentPosition.PositionY++;
                        ChangeCaseType(currentPosition.PositionX, currentPosition.PositionY, futureOrientation, destinationType);
                        activeCases.Push(currentCase);
                        nbVisitedCases++;
                        break;
                    case 4:
                        currentPosition.PositionX--;
                        ChangeCaseType(currentPosition.PositionX, currentPosition.PositionY, futureOrientation, destinationType);
                        activeCases.Push(currentCase);
                        nbVisitedCases++;
                        break;
                }
                
            }

            return board;
        }

        public int GetFutureDirection()
        {
            List<int> possibleMove = new List<int>();
            Random random = new Random();

            if (directionHistory.Count == 0)
            {
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
            }
            else
            {
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
            }
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
        public void ChangeCaseType(int indexX, int indexY, int orientation, int destinationType)
        {
            if (indexX > 0 && indexY > 0)
            {
                if (indexX <= board.Width - 1 && indexY <= board.Height)
                {
                    switch (destinationType)
                    {
                        case 1:
                            board.BoardContent[indexY].LineContent[indexX] = new CornerCase(indexX, indexY, orientation);
                            break;
                        case 2:
                            board.BoardContent[indexY].LineContent[indexX] = new DeadEnd(indexX, indexY, orientation);
                            break;
                        case 3:
                            board.BoardContent[indexY].LineContent[indexX] = new CrosswayCase(indexX, indexY, orientation);
                            break;
                        case 4:
                            board.BoardContent[indexY].LineContent[indexX] = new CorridorCase(indexX, indexY, orientation);
                            break;
                        case 5:
                            board.BoardContent[indexY].LineContent[indexX] = new TShapeCase(indexX, indexY, orientation);
                            break;
                    }
                }
            }

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

        public bool CanGoUp()
        {
            if (TopCase() != null)
            {
                if (TopCase().GetType() != typeof(WallCase))
                {
                    if (currentPosition.PositionY >= 1)
                    {
                        if (TopCase().GetType() == typeof(VoidCase))
                        {
                            return true;
                        }

                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
        public bool CanGoRight()
        {
            if (RightCase() != null)
            {
                if (RightCase().GetType() != typeof(WallCase))
                {
                    if (currentPosition.PositionX < board.Width-1)
                    {
                        if (RightCase().GetType() == typeof(VoidCase) || RightCase().GetType() == typeof(DeadEnd))
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
        public bool CanGoDown()
        {
            if (BottomCase() != null)
            {
                if (BottomCase().GetType() != typeof(WallCase))
                {
                    if (currentPosition.PositionY < board.Height-1)
                    {
                        if (BottomCase().GetType() == typeof(VoidCase))
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
        public bool CanGoLeft()
        {
            if (LeftCase() != null)
            {
                if (LeftCase().GetType() != typeof(WallCase))
                {
                    if (currentPosition.PositionX >= 1)
                    {
                        if (LeftCase().GetType() == typeof(VoidCase))
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
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
