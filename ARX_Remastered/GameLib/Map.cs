using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Map
    {
        private static int xMax = 10;
        private static int yMax = 10;
        private VoidCase voidCase = new VoidCase();
        private Case[,] mapContent=new Case[xMax, yMax];
        private List<List<bool>> borderMap = new List<List<bool>>();
        private int mapSeed;
        public Map()
        {
            mapSeed = GenerateSeed(20);
           /// mapContent = GenerateVoidMap();
            GenerateBorderMap();
            //GenerateBorder
        }

        public int GenerateSeed(int seedSize)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {

                byte[] rno = new byte[seedSize];
                rg.GetBytes(rno);
                int seed = BitConverter.ToInt32(rno, 0);
                return seed;
            }
            
        }
        public void GenerateVoidMap()
        {
            for (int i = 0; i < xMax; i++)
            {
                for (int j = 0; j < yMax; j++)
                {
                    mapContent.SetValue(voidCase,i,j);
                }
            }
        }

        public void GenerateBorderMap()
        {
            int iteration = new int();

            bool isWallNorth = false;
            bool isWallEast = false;
            bool isWallSouth = false;
            bool isWallWest = false;
            bool collition;

            Random rand = new Random();

            

            foreach (var mapCase in borderMap)
            {
                var caseType = rand.Next(0, 5);
                iteration++;
                switch (caseType)
            {
                //Void
                case 0:

                    break;
                //Dead end
                case 1:
                    isWallNorth = true;
                    isWallEast = true;
                    isWallSouth = false;
                    isWallWest = true;
                    break;
                //Corner
                case 2:
                    isWallNorth = true;
                    isWallEast = false;
                    isWallSouth = false;
                    isWallWest = true;
                    break;
                //Corridor
                case 3:
                    isWallNorth = false;
                    isWallEast = true;
                    isWallSouth = false;
                    isWallWest = true;
                    break;
                //T
                case 4:
                    isWallNorth = true;
                    isWallEast = false;
                    isWallSouth = false;
                    isWallWest = false;
                    break;
            }
                mapCase.Add(isWallNorth);
                mapCase.Add(isWallEast);
                mapCase.Add(isWallSouth);
                mapCase.Add(isWallWest);
            }
        }
        public Case[,] MapContent
        {
            get { return mapContent; }
        }

        public int MapSeed
        {
            get { return mapSeed; }
        }
    }



    
    


    
}
