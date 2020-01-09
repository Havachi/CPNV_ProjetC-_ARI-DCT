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
        private int nbVisitedCases=0;

        protected int width;
        protected int height;

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
            
            if (randomGeneration)
            {
                board = GenerateMap();
            }
            else
            {
                board = GenerateFixedMap();
            }
        }

        /// <summary>
        /// Generate a map that is always the same
        /// </summary>
        /// <returns>The board of the map</returns>
        public Board GenerateFixedMap()
        {
            for (int i = 0; i < 10; i++)
            {
                board.BoardContent.Add(new BoardLine(10));
            }
            Case terrainCase = new TerrainCase(0,0);
            Case wallCase = new WallCase(0,0);
            Case startCase = new StartCase(0,0);
            Case endCase = new EndCase(0,0);
            BoardLine boardLine = new BoardLine();
            board.BoardContent[0] = new BoardLine(new List<Case>()
            {
                wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase
            });
            board.BoardContent[1] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,terrainCase,terrainCase,wallCase,terrainCase,wallCase,terrainCase,terrainCase,wallCase
            });
            board.BoardContent[2] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,wallCase,terrainCase,wallCase,terrainCase,wallCase,wallCase,terrainCase,wallCase
            });
            board.BoardContent[3] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,wallCase,terrainCase,wallCase,terrainCase,terrainCase,terrainCase,terrainCase,wallCase
            });
            board.BoardContent[4] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,wallCase,terrainCase,wallCase,terrainCase,wallCase,wallCase,terrainCase,wallCase
            });
            board.BoardContent[5] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,wallCase,wallCase,wallCase,terrainCase,terrainCase,wallCase,terrainCase,wallCase
            });
            board.BoardContent[6] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,terrainCase,terrainCase,terrainCase,terrainCase,wallCase,wallCase,terrainCase,wallCase
            });
            board.BoardContent[7] = new BoardLine(new List<Case>()
            {
                wallCase,terrainCase,wallCase,wallCase,wallCase,terrainCase,terrainCase,wallCase,terrainCase,wallCase
            });
            board.BoardContent[8] = new BoardLine(new List<Case>()
            {
                wallCase,startCase,wallCase,terrainCase,terrainCase,terrainCase,wallCase,endCase,terrainCase,wallCase
            });
            board.BoardContent[9] = new BoardLine(new List<Case>()
            {
                wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase,wallCase
            });
            return board;
        }

        /// <summary>
        /// Generate a random map everytime
        /// </summary>
        /// <returns>The board of the map</returns>
        public Board GenerateMap()
        {
            //todo generate borders
            //todo create rules to make the map playable
            BoardLine tempboardLine = new BoardLine();

            //Generate an empty board with void case
            for (int i = 0; i < board.Height-1; i++)
            {
                for (int j = 0; j < board.Width-1; j++)
                {
                    tempboardLine.AddCase(new VoidCase(i,j));
                }

                board.AddLine(tempboardLine);
            }

            //Choose a random Starting point
            Random random = new Random();
            int randX = random.Next(board.Width);
            int randY = random.Next(board.Height);
            Position startPosition = new Position(randX,randY);
            currentPosition = startPosition;


            Stack<int> activeCases = new Stack<int>();
            

            while (activeCases.Count > 0)
            {
                var futurDirection = GetFuturDirection();
                switch (futurDirection)
                {
                    case 0:
                        activeCases.Pop();
                        break;
                    case 1:
                        ChangeCaseType(currentPosition.PositionX,currentPosition.PositionY,1,new DeadEnd(0,0,0));
                        
                        currentPosition.PositionY--;
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                OpenCurrentCase(futurDirection);
            }

            return board;
        }

        public int GetFuturDirection()
        {
            List<int> possibleMove = new List<int>();
            Random random = new Random();

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

            if (possibleMove.Count == 0)
            {
                return 0;
            }

            int r = random.Next(possibleMove.Count);
            return possibleMove[r];
        }


        #region Generator Methods



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
        /// <summary>
        /// Represent the case that is on the right of the current case
        /// </summary>
        /// <returns></returns>
        public Case RightCase()
        {
            if (currentPosition.PositionX != width)
            {
                return board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX+1];
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
            if (currentPosition.PositionY != height)
            {
                return board.BoardContent[currentPosition.PositionY + 1].LineContent[currentPosition.PositionX];
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


        public void ChangeCaseType(int indexX, int indexY,int orientation, Case destinationType)
        {
            var caseTochange = board.BoardContent[indexY].LineContent[indexX];
            switch (destinationType)
            {
                case CornerCase cornerCase:
                    caseTochange = new CornerCase(indexX,indexY,orientation);
                    break;
                case DeadEnd deadEnd:
                    caseTochange = new DeadEnd(indexX, indexY, orientation);
                    break;
                case CrosswayCase crosswayCase:
                    caseTochange = new CrosswayCase(indexX, indexY,orientation);
                    break;
                case CorridorCase corridorCase:
                    caseTochange = new CorridorCase(indexX, indexY,orientation);
                    break;
                case TShapeCase shapeCase:
                    caseTochange = new TShapeCase(indexX, indexY,orientation);
                    break;
            }
        }

        public Case SearchInBoard(int indexX, int indexY)
        {
            return board.BoardContent[indexY].LineContent[indexX];
        }

        public void OpenCurrentCase(int direction)
        {
            var currentCase = Self();
            var x = currentPosition.PositionX;
            var y = currentPosition.PositionY;

            switch (currentCase)
            {
                case CornerCase cornerCase:
                    switch (Self().Orientation)
                    {
                        case 1:
                            if (direction == 1)
                            {
                                currentCase = new TShapeCase(currentPosition.PositionX,currentPosition.PositionY,4);
                            }
                            else if (direction == 4)
                            {
                                currentCase = new TShapeCase(currentPosition.PositionX, currentPosition.PositionY,1);
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
                case DeadEnd deadEnd:
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
                case CorridorCase corridorCase:
                    switch (currentCase.Orientation)
                    {
                        case 1:

                            break;
                        case 2:
                            break;

                    }
                    break;
                case TShapeCase shapeCase:
                   
                    break;
            }
        }
        #endregion

        #region Generation Rules Method

        public bool CanGoUp()
        {
            if (TopCase() != null)
            {

            }
            return false;
        }
        public bool CanGoRight()
        {
            if (RightCase() != null)
            {
            }

            return false;
        }
        public bool CanGoDown()
        {
            if (BottomCase() != null)
            {

            }
            return false;
        }
        public bool CanGoLeft()
        {
            if (LeftCase() != null)
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
