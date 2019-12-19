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

        public MapDrawer(Board board)
        {
           mapImage = DrawMap(board);
        }

        public MapImage DrawMap(Board board)
        {
            int posX = 0;
            int posY = 0;
            graphics.FillRectangle(Brushes.White,0,0,500,500);

            foreach (var boardLine in board.BoardContent)
            {
                for (int i = 0; i < boardLine.Count; i++)
                {
                    if (boardLine[i].GetType() == typeof(WallCase))
                    {
                        graphics.FillRectangle(Brushes.Black,posX,posY,49,49);
                    }
                    posX += 50;
                }

                posX = 0;
                posY += 50;
            }

            mapImage.MapBitmap.Save("C:\\cmieux.bmp");
            return mapImage;
        }
    }
}
