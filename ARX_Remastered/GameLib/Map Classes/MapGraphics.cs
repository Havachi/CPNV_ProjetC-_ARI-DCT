using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLib
{
    public class MapGraphics
    {
        //private static string projectFolderPath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent?.FullName}";
        private static string projectFolderPath = $"C:\\CPNV_Project\\CSharp\\CPNV_ProjetC#_ARI+DCT";
        private static string assetsFolderPath = $"{projectFolderPath}\\ARX_Remastered\\Assets\\Map";
        private static string deadEndsAssetsPath = $"{assetsFolderPath}\\DeadEnd";
        private static string cornersAssetsPath = $"{assetsFolderPath}\\Corner";
        private static string corridorAssetsPath = $"{assetsFolderPath}\\Corridor";
        private static string crossWayAssetsPath = $"{assetsFolderPath}\\CrossWay";
        private static string tShapeAssetsPath = $"{assetsFolderPath}\\T";


        private List<string> mapCaseTypeList = new List<string>();
        private List<Point> mapCasePositions = new List<Point>();
        private List<Bitmap> mapGraphicsList = new List<Bitmap>();
        private List<Wall> wallsInfoList = new List<Wall>();
        
        private static Bitmap fullMap = new Bitmap(500, 500);
        private Graphics drawingTools = Graphics.FromImage(fullMap);

        private static int maxHeight = 10;
        private static int maxWidth = 10;
        private int caseToDraw = maxHeight * maxWidth;


        public void DrawMap(List<Wall> fullWallsList)
        {
            wallsInfoList = fullWallsList;
            DetermineCaseType();
            string imagePath = "";
            int imageOrientation = 0;
            //todo foreach type of wall assign a position, and an  orientation
            //todo draw one-by-one each entry in mapGraphicslist on an .bmp
            //todo save everything

            foreach (var wallType in mapCaseTypeList)
            {
                switch (wallType)
                {
                    //Dead End
                    case "DE-S":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = 1;
                        break;
                    case "DE-W":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = 2;
                        break;
                    case "DE-E":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = 3;
                        break;
                    case "DE-N":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = 4;
                        break;

                    //Corners
                    case "C-ES":
                        imagePath = cornersAssetsPath;
                        imageOrientation = 1;
                        break;
                    case "C-SW":
                        imagePath = cornersAssetsPath;
                        imageOrientation = 2;
                        break;
                    case "C-NW":
                        imagePath = cornersAssetsPath;
                        imageOrientation = 3;
                        break;
                    case "C-NE":
                        imagePath = cornersAssetsPath;
                        imageOrientation = 4;
                        break;

                    
                    //Corridors
                    case "CO-NS":
                        imagePath = corridorAssetsPath;
                        imageOrientation = 1;
                        break;
                    case "CO-WE":
                        imagePath = corridorAssetsPath;
                        imageOrientation = 2;
                        break;

                    //T-Shaped
                    case "T-ESW":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = 1;
                        break;
                    case "T-NSW":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = 2;
                        break;
                    case "T-NEW":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = 3;
                        break;
                    case "T-NES":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = 4;
                        break;

                    //Crossway
                    case "CR":
                        imagePath = crossWayAssetsPath;
                        imageOrientation = 1;
                        break;
                }

                //todo Draw on the bitmap
                Image image = new Bitmap($"{imagePath}\\50x50.bmp");
                Point destinationPoint = new Point(0,0);
                drawingTools.DrawImage(image,destinationPoint);
                int posX = 0;
                int posY = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        switch (imageOrientation)
                        {
                            case 1:
                                //nothing to do
                                break;
                            case 2:
                                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case 3:
                                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case 4:
                                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                        }
                        drawingTools.DrawImage(image, destinationPoint);
                        destinationPoint.X += image.Width;

                    }
                    destinationPoint.X = 0;
                    destinationPoint.Y += image.Width;
                }


            }
            fullMap.Save("C:\\Ausekourmek.bmp");

        }
        /// <summary>
        ///  This method determine which kind of wall for the drawing
        /// </summary>
        /// <remarks>
        /// Code for wall type determination:
        ///     [type of case]-[where there is no wall]
        /// All possible type of case:
        ///     DE : Dead End
        ///     C  : Corner
        ///     CO : Corridor
        ///     CR : Cross Way
        ///     T  : T-shaped
        /// </remarks>
        /// <returns></returns>
        public void DetermineCaseType()
        {
            foreach (var wall in wallsInfoList)
            {
                string wallType = "";
                //If the wall is a dead end
                if (wall.IsWallNorth && wall.IsWallEast && wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "DE-S";
                }
                else if (wall.IsWallNorth && wall.IsWallEast && !wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "DE-W";
                }
                else if (wall.IsWallNorth && !wall.IsWallEast && wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "DE-E";
                }
                else if (!wall.IsWallNorth && wall.IsWallEast && wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "DE-N";
                }

                //If the wall is a Corner
                else if (wall.IsWallNorth && wall.IsWallEast && !wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "C-SW";
                }
                else if (!wall.IsWallNorth && wall.IsWallEast && !wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "C-NW";
                }
                else if (!wall.IsWallNorth && !wall.IsWallEast && wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "C-NE";
                }
                else if (wall.IsWallNorth && !wall.IsWallEast && wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "C-ES";
                }

                //If the wall is a Corridor
                else if (!wall.IsWallNorth && wall.IsWallEast && wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "CO-NS";
                }
                else if (wall.IsWallNorth && !wall.IsWallEast && !wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "CO-WE";
                }

                //If the wall is T-Shaped
                else if (wall.IsWallNorth && !wall.IsWallEast && !wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "T-ESW";
                }
                else if (!wall.IsWallNorth && wall.IsWallEast && !wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "T-NSW";
                }
                else if (!wall.IsWallNorth && !wall.IsWallEast && wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "T-NEW";
                }
                else if (!wall.IsWallNorth && !wall.IsWallEast && !wall.IsWallWest && wall.IsWallSouth)
                {
                    wallType = "T-NES";
                }
                //If the wall is a CrossWay
                else if (!wall.IsWallNorth && !wall.IsWallEast && !wall.IsWallWest && !wall.IsWallSouth)
                {
                    wallType = "CR";
                }
                mapCasePositions.Add(new Point(wall.PosX, wall.PosY));
                mapCaseTypeList.Add(wallType);
            }
        }
    }
}
