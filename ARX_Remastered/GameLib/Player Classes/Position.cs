using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLib
{
    public class Position
    {
        
        private int positionX;
        private int positionY;

        public Position(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public int PositionY
        {
            get { return positionY;}
            set { positionY =value; }
        }
    }
}
