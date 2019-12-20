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

        public MapGenerator()
        {
           board = new Board(10,10);
           board = GenerateFixedMap();
           board = ValidateMap();
        }
        public MapGenerator(int maxHeight, int maxWidth)
        {
            board = new Board(maxHeight, maxWidth);
            board = GenerateFixedMap();
            board = ValidateMap();

        }

        
               /// <summary>
                /// read a .txt file that contain chars to create an map
                /// </summary>
                /// <returns></returns>
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
                
        public Board GenerateMap()
        {
            for (int i = 0; i < board.Height; i++) 
            {
                board.BoardContent.Add(new BoardLine(board.Width));
            }

            //generate top border
            for (int i = 0; i < board.BoardContent[0].LineContent.Capacity; i++)
            {
                board.BoardContent[0].LineContent.Add(new WallCase());
            }
            for (int i = 0; i < board.BoardContent[0].LineContent.Capacity; i++)
            {
                board.BoardContent[9].LineContent.Add(new WallCase());
            }


            Random random = new Random();
            int rand = 0;
            int actualline = 0;
            foreach (var boardLine in board.BoardContent)
            {
                if (boardLine.LineContent.Capacity > boardLine.LineContent.Count)
                {
                    for (int i = 0; i < boardLine.LineContent.Capacity; i++)
                    {
                        if (i > 0 && i < boardLine.LineContent.Capacity-1)
                        {
                            rand = random.Next() % 4;
                            if (rand <= 0)
                            {
                                boardLine.LineContent.Add(new WallCase());
                            }
                            else
                            {
                                boardLine.LineContent.Add(new TerrainCase());
                            }
                        }
                        else if(i <= 0 || i == boardLine.LineContent.Capacity)
                        {
                            boardLine.LineContent.Add(new WallCase());
                        }
                    }

                    board.BoardContent[actualline].LineContent = boardLine.LineContent;
                    actualline++;
                }
                else
                {
                    actualline++;
                }
            }
            

            
            

            return board;
        }

        public Board ValidateMap()
        {

            
            return board;
        }

        public Board Board
        {
            get { return board; }
        }
    }
}
