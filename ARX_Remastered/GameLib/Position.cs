using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Position
    {
        private string positionX;
        private string positionY;


        public Position(string positionX, string positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public string PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public string PositionY
        {
            get { return positionY;}
            set { positionY = value; }
        }
    }
}
