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
            mapImage = new MapImage(board.Height * 100 ,board.Width * 100 );
            graphics = Graphics.FromImage(mapImage.MapBitmap);
            mapImage = DrawMap(board);
        }

        public MapImage DrawMap(Board board)
        {
            int posX = 0;
            int posY = 0;
            int caseWidth = 48;
            int caseHeight = 48;
            graphics.FillRectangle(Brushes.White,posX,posY,mapImage.ImageWidth,mapImage.ImageHeight);

            foreach (var boardLine in board.BoardContent)
            {
                foreach (var lineCase in boardLine.LineContent)
                {
                    if (lineCase.GetType() == typeof(WallCase))
                    {
                        graphics.FillRectangle(Brushes.Black,posX,posY, caseWidth, caseHeight);
                    }
                    else if (lineCase.GetType() == typeof(TerrainCase))
                    {
                        graphics.FillRectangle(Brushes.WhiteSmoke, posX, posY, caseWidth, caseHeight);
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
