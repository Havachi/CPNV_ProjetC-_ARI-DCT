using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;

namespace GameLib
{
    public class MapGenerator
    {
        private Board board;
        private TerrainCase terrainCase;
        private WallCase wallCase;
        private VoidCase voidCase;

        private List<Case> lineOfCases;

       public MapGenerator()
       {
           terrainCase = new TerrainCase();
           wallCase = new WallCase();
           voidCase = new VoidCase();
           board = new Board(10,10);
       }

       public Board Generate()
       {
           return board;
       }
        /// <summary>
        /// read a .txt file that contain chars to create an map
        /// </summary>
        /// <returns></returns>
       public Board ReadMap()
        {
            char[,] mapchars = new char[10, 10];
            string tempString;
            List<Case> lineList = new List<Case>();

            using (System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\CPNV_Project\CSharp\CPNV_ProjetC#_ARI+DCT\ARX_Remastered\TestMap\Map1.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    tempString = file.ReadLine();
                    for (int j = 0; j < 10; j++)
                    {
                        if (tempString != null) mapchars[i, j] = tempString[j];
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                    for (int j = 0; j < 10; j++)
                    {
                        if (mapchars[i, j] == '#')
                        {
                            lineList.Add(wallCase);
                        }
                        else if (mapchars[i, j] == '-')
                        {
                            lineList.Add(terrainCase);
                        }
                        else
                        {
                            lineList.Add(voidCase);
                        }
                    }
                    board.BoardContent.Add(lineList);
            }
            
            return board;
        }

    }
}
