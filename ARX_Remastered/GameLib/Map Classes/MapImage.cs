using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    /// <summary>
    /// This class represent the graphical image that represent the generated board
    /// </summary>
    public class MapImage
    {
        private int horizontalSize;
        private int verticalSize;
        private Bitmap mapBitmap;
        private Board board;
        public MapImage()
        {
            mapBitmap = new Bitmap(500, 500);
            this.horizontalSize = 500;
            this.verticalSize = 500;
        }

        public MapImage(int horizontalSize, int verticalSize)
        {
            mapBitmap = new Bitmap(HorizontalSize, VerticalSize);
            this.horizontalSize = horizontalSize;
            this.verticalSize = verticalSize;
        }

        public int HorizontalSize
        {
            get { return horizontalSize; }
        }

        public int VerticalSize
        {
            get { return verticalSize; }
        }

        public Bitmap MapBitmap
        {
            get { return mapBitmap; }
        }
    }
}
