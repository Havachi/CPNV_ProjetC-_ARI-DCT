using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLib
{
    public class MapGraphics
    {

        private Bitmap corner = new Bitmap(@"..\Assets\Map\Corner");


        private static int maxHeight = 10;
        private static int maxWidth = 10;
        private int caseToDraw = maxHeight * maxWidth;

        public void DrawMap()
        {
            Bitmap mapBitmap = new Bitmap(500, 500);
            Graphics flagGraphics = Graphics.FromImage(mapBitmap);
            mapBitmap.Save(@"C:\oscourmek.bmp");
        }
    }
}
