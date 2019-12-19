using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;

namespace GameLib
{
    public class MapGenerator
    {
        private Board board;
        private List<List<Case>> boardContent;
        private TerrainCase terrainCase;
        private WallCase wallCase;
        private VoidCase voidCase;


       public MapGenerator()
       {
           terrainCase = new TerrainCase();
           wallCase = new WallCase();
           voidCase = new VoidCase();
           board = new Board(10,10);
           boardContent = new List<List<Case>>();
       }

       public Board Generate()
       {
           return board;
       }
        /// <summary>
        /// read a .txt file that contain chars to create an map
        /// </summary>
        /// <returns></returns>
       public List<List<Case>> ReadMap()
        {
            char[,] mapchars = new char[10, 12];
            string tempString;
            int counter = 0;
            List<Case> lineList = new List<Case>();
            string directory = @"C:\CPNV_Project\CSharp\CPNV_ProjetC#_ARI+DCT\ARX_Remastered\TestMap\Map1.txt";
            for (int i = 0; i < mapchars.GetLength(0); i++)
            {
                for (int j = 0; j < mapchars.GetLength(1); j++)
                {
                    //mapchars[i, j] = (Char)File.ReadAllBytes(directory)[counter];
                    mapchars[i, j] = (Char) File.ReadAllText(directory)[counter];
                    ++counter;
                }
            }

            counter = 0;
            List<Case> mapLine = new List<Case>();



            for (int i = 0; i < mapchars.GetUpperBound(0); i++)
            {
                for (int j = 0; j < mapchars.GetUpperBound(1); j++)
                {
                    if (mapchars[i,j] == '#')
                    {
                        mapLine.Add(wallCase);
                    }
                    else if (mapchars[i,j] == '-')
                    {
                        mapLine.Add(terrainCase);
                    }
                    else
                    {
                        mapLine.Add(voidCase);
                    }
                }
                boardContent.Add(mapLine);
                mapLine.Clear();
            }
            return boardContent;
        }

       public Board GenerateMap()
       {
            throw new NotImplementedException();
       }
    }
}
