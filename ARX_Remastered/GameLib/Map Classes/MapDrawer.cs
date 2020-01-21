using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public HatchStyle wallStyle = HatchStyle.Plaid;
        //10,20,50 or 100
        private int caseWidth = 20;
        private int caseHeight = 20;
        private int caseSeparation = 0;

        private bool useDrawByType = false;

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

            Point horizontalStartPoint = new Point();
            Point horizontalEndPoint = new Point();
            Point verticalStartPoint = new Point();
            Point verticalEndPoint = new Point();
            

            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            //string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string mapAssetsPath = $@"{projectPath}\Assets\Map";
            string mapSavePath = $@"{projectPath}\Outputs";

            //Images path
            Image cornerImage = Image.FromFile($@"{mapAssetsPath}\Corner\Corner{caseWidth}x{caseHeight}.bmp");
            Image corridorImage = Image.FromFile($@"{mapAssetsPath}\Corridor\Corridor{caseWidth}x{caseHeight}.bmp");
            Image crossWayImage = Image.FromFile($@"{mapAssetsPath}\CrossWay\Crossway{caseWidth}x{caseHeight}.bmp");
            Image deadEndImage = Image.FromFile($@"{mapAssetsPath}\DeadEnd\DeadEnd{caseWidth}x{caseHeight}.bmp");
            Image tShapeImage = Image.FromFile($@"{mapAssetsPath}\T\T{caseWidth}x{caseHeight}.bmp");
            Image startImage = Image.FromFile($@"{mapAssetsPath}\Start\Start{caseWidth}x{caseHeight}.bmp");

            //stream for the savingpath
            Stream stream = new FileStream($@"{mapSavePath}\Map{mapImage.ImageWidth}x{mapImage.ImageHeight}.bmp", FileMode.Create);

            //drawing tools
            HatchBrush brick = new HatchBrush(HatchStyle.HorizontalBrick, Color.Aquamarine, Color.Gray);
            HatchBrush other = new HatchBrush(HatchStyle.Trellis, Color.Black, Color.Transparent);
            HatchStyle terrainStyle = HatchStyle.Percent90;
            HatchStyle startStyle = HatchStyle.Sphere;

            Pen horizontalLinePen;
            Pen verticalLinePen;

            //Draw the background
            graphics.FillRectangle(other, posX,posY,mapImage.ImageWidth,mapImage.ImageHeight);

            if (useDrawByType)
            {
                foreach (var boardLine in board.BoardContent)
                {
                    foreach (var lineCase in boardLine.LineContent)
                    {
                        Rectangle r = new Rectangle(lineCase.IndexX * caseWidth, lineCase.IndexY * caseHeight, caseWidth, caseHeight);
                        if (lineCase.GetType() == typeof(WallCase))
                        {
                            graphics.FillRectangle(new HatchBrush(wallStyle, Color.Black, Color.DimGray), r);
                        }

                        else if (lineCase.GetType() == typeof(DeadEnd))
                        {
                            graphics.FillRectangle(new HatchBrush(terrainStyle, Color.White, Color.DimGray), r);
                        }
                        else if (lineCase.GetType() == typeof(CornerCase))
                        {
                            graphics.FillRectangle(new HatchBrush(terrainStyle, Color.White, Color.DimGray), r);
                            //graphics.DrawImage(cornerImage, posX, posY, caseWidth, caseHeight);
                            //graphics.FillRectangle(Brushes.Violet, posX, posY, caseWidth, caseHeight);
                        }
                        else if (lineCase.GetType() == typeof(CrosswayCase))
                        {
                            graphics.FillRectangle(new HatchBrush(terrainStyle, Color.White, Color.DimGray), r);
                            //graphics.DrawImage(crossWayImage, posX, posY, caseWidth, caseHeight);
                            //graphics.FillRectangle(Brushes.DarkOliveGreen, posX, posY, caseWidth, caseHeight);
                        }
                        else if (lineCase.GetType() == typeof(CorridorCase))
                        {
                            graphics.FillRectangle(new HatchBrush(terrainStyle, Color.White, Color.DimGray), r);
                            //graphics.DrawImage(corridorImage, posX, posY, caseWidth, caseHeight);
                            //graphics.FillRectangle(Brushes.White, posX, posY, caseWidth, caseHeight);
                        }
                        else if (lineCase.GetType() == typeof(TShapeCase))
                        {
                            graphics.FillRectangle(new HatchBrush(terrainStyle, Color.White, Color.DimGray), r);
                            //graphics.DrawImage(tShapeImage, posX, posY, caseWidth, caseHeight);
                            //graphics.FillRectangle(Brushes.Blue, posX, posY, caseWidth, caseHeight);
                        }
                        else if (lineCase.GetType() == typeof(StartCase))
                        {
                            graphics.FillRectangle(new HatchBrush(startStyle, Color.LawnGreen, Color.White), r);
                        }
                        else if (lineCase.GetType() == typeof(EndCase))
                        {
                            graphics.FillRectangle(Brushes.DarkRed, posX, posY, caseWidth, caseHeight);
                            graphics.FillRectangle(Brushes.Red, posX + 5, posY + 5, caseWidth - 10, caseHeight - 10);
                            graphics.FillRectangle(Brushes.DarkRed, posX + 10, posY + 10, caseWidth - 20,
                                caseHeight - 20);
                        }
                        else
                        {
                            graphics.FillRectangle(Brushes.Transparent, posX, posY, caseWidth, caseHeight);
                        }

                        /*
                        if (imageToDraw != null)
                        {
                            switch (lineCase.Orientation)
                            {
                                case 1:
                                    imageToDraw.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                                    break;
                                case 2:
                                    imageToDraw.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    break;
                                case 3:
                                    imageToDraw.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    break;
                                case 4:
                                    imageToDraw.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    break;
                            }

                            graphics.DrawImage(imageToDraw, posX, posY, caseWidth, caseHeight);
                        }
                        */

                        posX += caseWidth + caseSeparation;
                    }

                    posX = 0;
                    posY += caseHeight + caseSeparation;
                }
            }
            else
            {
                verticalStartPoint.X = 0;
                verticalStartPoint.Y = 0;

                verticalEndPoint.X = 0;
                verticalEndPoint.Y = caseHeight;

                horizontalStartPoint.X = 0;
                horizontalStartPoint.Y = 0;

                horizontalEndPoint.X = caseWidth;
                horizontalEndPoint.Y = 0;
                Case lastCase = null;
                int counter = 0;
                
                horizontalLinePen = new Pen(new HatchBrush(HatchStyle.Percent90,Color.White),2);
                verticalLinePen = new Pen(new HatchBrush(HatchStyle.Percent90, Color.White), 2);

                foreach (var boardLine in board.BoardContent)
                {
                    foreach (var aCase in boardLine.LineContent)
                    {
                        if (aCase.GetType() == typeof(WallCase))
                        {
                            Rectangle r = new Rectangle(horizontalStartPoint.X,horizontalStartPoint.Y, caseWidth,caseHeight);
                            graphics.FillRectangle(new HatchBrush(wallStyle, Color.Black, Color.DimGray),r);
                        }
                        else if (aCase.GetType() == typeof(StartCase))
                        {
                            Rectangle r = new Rectangle(horizontalStartPoint.X, horizontalStartPoint.Y, caseWidth, caseHeight);
                            graphics.FillRectangle(new HatchBrush(HatchStyle.DiagonalBrick, Color.LawnGreen, Color.White), r);
                        }
                        else if (aCase.GetType() == typeof(EndCase))
                        {
                            Rectangle rectfull = new Rectangle(horizontalStartPoint.X, horizontalStartPoint.Y, caseWidth, caseHeight);
                            Rectangle r = new Rectangle(horizontalStartPoint.X+caseWidth/4, horizontalStartPoint.Y+caseHeight/4, caseWidth/2, caseHeight/2);
                            graphics.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.White), rectfull);
                            graphics.FillRectangle(new HatchBrush(HatchStyle.Sphere, Color.Red, Color.White), r);
                            
                        }
                        else
                        {
                            //aCase.AssignWall();
                            if (aCase.Walls[0])
                            {
                                graphics.DrawLine(horizontalLinePen, horizontalStartPoint, horizontalEndPoint);

                            }
                            else
                            {
                                //graphics.DrawLine(Pens.Yellow, horizontalStartPoint, horizontalEndPoint);
                            }

                            if (aCase.Walls[1])
                            {
                                verticalStartPoint.X += caseWidth;
                                verticalEndPoint.X += caseWidth;
                                graphics.DrawLine(verticalLinePen, verticalStartPoint, verticalEndPoint);
                                verticalStartPoint.X -= caseWidth;
                                verticalEndPoint.X -= caseWidth;
                            }
                            else
                            {
                                //graphics.DrawLine(Pens.White, verticalStartPoint, verticalEndPoint);
                            }

                            if (aCase.Walls[2])
                            {
                                horizontalStartPoint.Y += caseHeight;
                                horizontalEndPoint.Y += caseHeight;
                                graphics.DrawLine(horizontalLinePen, horizontalStartPoint, horizontalEndPoint);
                                horizontalStartPoint.Y -= caseHeight;
                                horizontalEndPoint.Y -= caseHeight;
                            }
                            else
                            {

                                //graphics.DrawLine(Pens.White, verticalStartPoint, verticalEndPoint);
                            }

                            if (aCase.Walls[3])
                            {
                                graphics.DrawLine(verticalLinePen, verticalStartPoint, verticalEndPoint);
                            }
                            else
                            {
                                //graphics.DrawLine(Pens.White, verticalStartPoint, verticalEndPoint);
                            }
                            Rectangle centerText = new Rectangle(horizontalStartPoint.X + caseWidth / 6, horizontalStartPoint.Y + caseHeight / 6, caseWidth , caseHeight );
                            graphics.DrawString($"{aCase.TypeToString()}",new Font(FontFamily.GenericMonospace,5,FontStyle.Regular ), Brushes.Yellow, centerText);
                        }

                        horizontalStartPoint.X += caseWidth;
                        horizontalEndPoint.X += caseWidth;

                        verticalStartPoint.X += caseWidth;
                        verticalEndPoint.X += caseWidth;
                        lastCase = aCase;
                    }

                    horizontalStartPoint.X = 0;
                    horizontalStartPoint.Y += caseHeight ;

                    horizontalEndPoint.X = horizontalStartPoint.X + caseWidth;
                    horizontalEndPoint.Y += caseHeight;

                    verticalStartPoint.X = 0;
                    verticalStartPoint.Y += caseHeight ;

                    verticalEndPoint.X = 0;
                    verticalEndPoint.Y += verticalStartPoint.Y + caseHeight;
                    
                }
            }


            mapImage.MapBitmap.Save(stream,ImageFormat.Bmp);

            return mapImage;
        }

        public void ChangeStyle()
        {
           
        }
    }
}
