using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

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






    }



    
    


    
}
