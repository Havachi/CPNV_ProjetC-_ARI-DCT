using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameLib;

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
                board = ValidateMap();
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
                board = ValidateMap();
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
            Case terrainCase = new TerrainCase();
            Case wallCase = new WallCase();
            Case startCase = new StartCase();
            Case endCase = new EndCase();
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

            //Generate an empty board with void case
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    board.BoardContent[i].LineContent[j] = new Case(i,j);
                }
            }

            //Choose a random Starting point
            Random random = new Random();
            int randX = random.Next(board.Width);
            int randY = random.Next(board.Height);
            Position startPosition = new Position(randX,randY);
            currentPosition = startPosition;
            nbVisitedCases++;
            while (nbVisitedCases < board.Height*board.Width)
            {
                foreach (var boardLine in board.BoardContent)
                {
                    foreach (var lineCase in boardLine.LineContent)
                    {
                        //check if up is possible
                        if (CanGoUp())
                        {
                            Self().Direction = Direction.Up;
                            currentPosition.PositionY -= 1;
                        }
                        //check if right is possible
                        if (CanGoRight())
                        {
                            Self().Direction = Direction.Right;
                            currentPosition.PositionX += 1;
                        }
                        //check if down is possible
                        if (CanGoDown())
                        {
                            Self().Direction = Direction.Down;
                            currentPosition.PositionY += 1;
                        }
                        //check if left is possible
                        if (CanGoLeft())
                        {
                            Self().Direction = Direction.Left;
                            currentPosition.PositionX -= 1;
                        }

                        if (NextCase().State == State.Void)
                        {
                            

                        }

                    }
                }
            }

            return board;
        }

        public Board ValidateMap()
        {

            
            return board;
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
            if (currentPosition.PositionY == 0)
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
            if (currentPosition.PositionX >= width)
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
            if (currentPosition.PositionY >= height)
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
            if (currentPosition.PositionX == 0)
            {
                return board.BoardContent[currentPosition.PositionY].LineContent[currentPosition.PositionX-1];
            }
            else
            {
                return null;
            }
        }

        public Case NextCase(Case nextCase)
        {
            this.nextCase = nextCase;
            return this.nextCase;
        }
        #endregion

        #region Generator Movement

        public bool CanGoUp()
        {
            if (TopCase() != null)
            {
                if (TopCase().State == State.Corner)
                {
                    if (TopCase().Direction == Direction.Up)
                    {
                        return true;
                    }
                    else if (TopCase().Direction == Direction.Right)
                    {
                        return true;
                    }
            
                }
                else if (TopCase().State == State.CrossWay)
                {
                    return true;
                }
                else if (TopCase().State == State.DeadEnd)
                {
                    if (TopCase().Direction == Direction.Up)
                    {
                        return true;
                    }
                }
                else if (TopCase().State == State.TShape)
                {
                    switch (TopCase().Direction)
                    {
                        case Direction.Up:
                        case Direction.Left:
                        case Direction.Right:
                            return true;
                    }
                }
                else if (TopCase().State == State.Corridor)
                {
                    if (TopCase().Direction == Direction.Up)
                    {
                        return true;
                    }
                }
                else if (TopCase().State == State.Void)
                {
                    //todo Choose the right state for a void case
                    
                }

                return false;
            }

            return false;
        }
        public bool CanGoRight()
        {
            if (RightCase() != null )
            {
                if (RightCase().Direction == Direction.Right)
                {
                    if (RightCase().State == State.Corner)
                    {
                        return true;
                    }
                    if (RightCase().State == State.DeadEnd)
                    {
                        return true;
                    }
                    if (RightCase().State == State.DeadEnd)
                    {
                        return true;
                    }
                    if (RightCase().State == State.Corridor)
                    {
                        return true;
                    }
                }
                else if (RightCase().Direction == Direction.Down)
                {
                    if (RightCase().State == State.Corner)
                    {
                        return true;
                    }
                }
                else if (RightCase().State == State.CrossWay)
                {
                    return true;
                }
                else if (RightCase().State == State.TShape)
                {
                    if (RightCase().Direction == Direction.Up || RightCase().Direction == Direction.Right || RightCase().Direction == Direction.Down)
                    {
                        return true;
                    }                    
                }
            }

            return false;
        }
        public bool CanGoDown()
        {
            return false;
        }
        public bool CanGoLeft()
        {
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
