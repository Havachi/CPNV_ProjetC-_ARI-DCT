using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Reflection;

namespace GameLib
{
    public class Wall
    {
        private bool isWallNorth;
        private bool isWallEast;
        private bool isWallSouth;
        private bool isWallWest;
        private int posX;
        private int posY;

        public Wall(bool isWallNorth, bool isWallEast, bool isWallSouth, bool isWallWest, int posX, int posY)
        {
            this.isWallNorth = isWallNorth;
            this.isWallEast = isWallEast;
            this.isWallSouth = isWallSouth;
            this.isWallWest = isWallWest;
            this.posX = posX;
            this.posY = posY;
        }

        public bool IsWallNorth
        {
            get { return isWallNorth; }
        }
        public bool IsWallEast
        {
            get { return isWallEast; }
        }
        public bool IsWallSouth
        {
            get { return isWallSouth; }
        }
        public bool IsWallWest
        {
            get { return isWallWest; }
        }

        public int PosX
        {
            get { return posX; }
        }

        public int PosY
        {
            get { return posY; }
        }
    }
}
