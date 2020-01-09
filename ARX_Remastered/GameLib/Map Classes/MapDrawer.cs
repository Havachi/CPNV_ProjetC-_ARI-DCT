using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            mapImage = new MapImage(board.Height * 20 ,board.Width * 20 );
            graphics = Graphics.FromImage(mapImage.MapBitmap);
            mapImage = DrawMap(board);
        }

        public MapImage DrawMap(Board board)
        {
            int posX = 0;
            int posY = 0;
            int caseWidth = 20;
            int caseHeight = 20;
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
                        graphics.FillRectangle(Brushes.Gray, posX, posY, caseWidth, caseHeight);
                    }
                    else if (lineCase.GetType() == typeof(StartCase))
                    {
                        graphics.FillRectangle(Brushes.DarkGreen, posX, posY, caseWidth, caseHeight);
                        graphics.FillRectangle(Brushes.GreenYellow, posX+5, posY+5, caseWidth-10, caseHeight-10);
                        graphics.FillRectangle(Brushes.DarkGreen, posX+10, posY+10, caseWidth-20, caseHeight-20);
                    }
                    else if (lineCase.GetType() == typeof(EndCase))
                    {
                        graphics.FillRectangle(Brushes.DarkRed, posX, posY, caseWidth, caseHeight);
                        graphics.FillRectangle(Brushes.Red, posX + 5, posY + 5, caseWidth - 10, caseHeight - 10);
                        graphics.FillRectangle(Brushes.DarkRed, posX + 10, posY + 10, caseWidth - 20, caseHeight - 20);
                    }

                    posX += 20;
                }
                posX = 0;
                posY += 20;
            }
            Stream stream = new FileStream($@"C:\tmp\Maze.bmp",FileMode.Create);
            mapImage.MapBitmap.Save(stream,ImageFormat.Bmp);

            return mapImage;
        }
    }
}
