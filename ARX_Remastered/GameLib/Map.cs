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
        private List<Case> mapContent= new List<Case>();
        private int mapSeed;
        public Map()
        {
            mapSeed = GenerateSeed(20);
            GenerateMap(mapSeed);
        }
        public Map(List<Case> mapContent)
        {
            this.mapContent = mapContent;
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
        public void GenerateMap(int levelSeed)
        {

        }

        public List<Case> MapContent
        {
            get { return mapContent; }
        }

        public int MapSeed
        {
            get { return mapSeed; }
        }
    }



    
    


    
}
