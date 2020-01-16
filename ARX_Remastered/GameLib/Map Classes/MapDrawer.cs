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
        private MapImage mapImage = new MapImage();
        private Graphics graphics;
        //10,20,50 or 100
        private int caseWidth = 20;

        //10,20,50 or 100
        private int caseHeight = 20;

        public MapDrawer(Board board)
        {
            mapImage = new MapImage(caseHeight * board.Height, caseWidth * board.Width);
            graphics = Graphics.FromImage(mapImage.MapBitmap);
            mapImage = DrawMap(board);
        }

        public MapImage DrawMap(Board board)
        {
            int posX = 0;
            int posY = 0;

            string debugprojectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string mapAssetsPath = $@"{debugprojectPath}\Assets\Map";
            string mapSavePath = $@"{debugprojectPath}\Outputs";

            Image cornerImage = Image.FromFile($@"{mapAssetsPath}\Corner\Corner{caseWidth}x{caseHeight}.bmp");
            Image corridorImage = Image.FromFile($@"{mapAssetsPath}\Corridor\Corridor{caseWidth}x{caseHeight}.bmp");
            Image crossWayImage = Image.FromFile($@"{mapAssetsPath}\CrossWay\Crossway{caseWidth}x{caseHeight}.bmp");
            Image deadEndImage = Image.FromFile($@"{mapAssetsPath}\DeadEnd\DeadEnd{caseWidth}x{caseHeight}.bmp");
            Image tShapeImage = Image.FromFile($@"{mapAssetsPath}\T\T{caseWidth}x{caseHeight}.bmp");

            graphics.FillRectangle(Brushes.White,posX,posY,mapImage.ImageWidth,mapImage.ImageHeight);

            foreach (var boardLine in board.BoardContent)
            {
                foreach (var lineCase in boardLine.LineContent)
                {
                    if (lineCase.GetType() == typeof(WallCase))
                    {
                        graphics.FillRectangle(Brushes.Black,posX,posY, caseWidth, caseHeight);
                    }

                    else if (lineCase.GetType() == typeof(DeadEnd))
                    {
                        graphics.DrawImage(deadEndImage,posX,posY, caseWidth, caseHeight);
                        //graphics.FillRectangle(Brushes.Yellow, posX, posY, caseWidth, caseHeight);
                    }
                    else if (lineCase.GetType() == typeof(CornerCase))
                    {
                        graphics.DrawImage(cornerImage, posX, posY, caseWidth, caseHeight);
                        //graphics.FillRectangle(Brushes.Violet, posX, posY, caseWidth, caseHeight);
                    }
                    else if (lineCase.GetType() == typeof(CrosswayCase))
                    {
                        graphics.DrawImage(crossWayImage, posX, posY, caseWidth, caseHeight);
                        //graphics.FillRectangle(Brushes.DarkOliveGreen, posX, posY, caseWidth, caseHeight);
                    }
                    else if (lineCase.GetType() == typeof(CorridorCase))
                    {
                        graphics.DrawImage(corridorImage, posX, posY, caseWidth, caseHeight);
                        //graphics.FillRectangle(Brushes.White, posX, posY, caseWidth, caseHeight);
                    }
                    else if (lineCase.GetType() == typeof(TShapeCase))
                    {
                        graphics.DrawImage(tShapeImage, posX, posY, caseWidth, caseHeight);
                        //graphics.FillRectangle(Brushes.Blue, posX, posY, caseWidth, caseHeight);
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
                    else
                    {
                        graphics.FillRectangle(Brushes.Transparent, posX, posY, caseWidth, caseHeight);
                    }

                    posX += 20;
                }
                posX = 0;
                posY += 20;
            }
            Stream stream = new FileStream($@"{mapSavePath}\Map{mapImage.ImageWidth}x{mapImage.ImageHeight}.bmp", FileMode.Create);
            mapImage.MapBitmap.Save(stream,ImageFormat.Bmp);
            stream.Close();
            return mapImage;
        }
    }
}
