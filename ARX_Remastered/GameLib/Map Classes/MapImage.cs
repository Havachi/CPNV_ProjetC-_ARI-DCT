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
        private int imageWidth;
        private int imageHeight;
        private Bitmap mapBitmap;
        private Board board;
        public MapImage()
        {
            mapBitmap = new Bitmap(500, 500);
            this.imageWidth = 500;
            this.imageHeight = 500;
        }

        public MapImage(int height, int width)
        {
            mapBitmap = new Bitmap(width, height);
            this.imageWidth = width;
            this.imageHeight = width;
        }

        public int ImageWidth
        {
            get { return imageWidth; }
        }

        public int ImageHeight
        {
            get { return imageHeight; }
        }

        public Bitmap MapBitmap
        {
            get { return mapBitmap; }
        }
    }
}
