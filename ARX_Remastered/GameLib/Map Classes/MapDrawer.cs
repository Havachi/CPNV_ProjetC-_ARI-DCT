using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    /// <summary>
    /// This method draw line on an image to represent the actual map
    /// </summary>
    public class MapDrawer
    {
        private MapImage mapImage;
        private Graphics graphics;
        public MapDrawer()
        {
            mapImage = new MapImage();
            graphics = Graphics.FromImage(mapImage.MapBitmap);
        }
        public MapImage DrawMap(Board board)
        {
            return mapImage
        }
    }
}
