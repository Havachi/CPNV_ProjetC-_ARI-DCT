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
        private static int columns =10;
        private static int rows=10 ;
        private int seedSize;

        private int[,] mapContent = new int[columns,rows];
        //private List<Case> mapContent = new List<Case>();
        private VoidCase voidCase = new VoidCase();
        private byte[] mapSeed;


        public Map()
        {
            seedSize = columns * rows;
            mapSeed = GenerateSeed(seedSize);
            LoadVoidMap();
        }
        public Map(int[,] mapContent)
        {
            this.mapContent = mapContent;
        }

        public byte[] GenerateSeed(int seedSize)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {

                byte[] rno = new byte[10];
                rg.GetBytes(rno);
                //int seed = BitConverter.ToInt32(rno, 0);
                return rno;
            }
            
        }
        public void LoadVoidMap()
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    mapContent[x,y] = 0;

                }
            }
        }


        public int[,] MapContent
        {
            get { return mapContent; }
        }

        public byte[] MapSeed
        {
            get { return mapSeed; }
        }

        public int Rows
        {
            get { return rows; }
        }
        public int Columns
        {
            get { return columns; }
        }
    }



    
    


    
}
