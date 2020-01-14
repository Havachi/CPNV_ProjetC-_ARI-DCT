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
        //For Release 
        //private static string projectFolderPath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent?.FullName}";
        //For Test
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

        /// <summary>
        /// Determine the orientation to use and draw on a .bmp different assets
        /// </summary>
        /// <param name="fullWallsList"></param>
        public void DrawMap(List<Wall> fullWallsList)
        {
            wallsInfoList = fullWallsList;
            DetermineCaseType();
            string imagePath = "";
            RotateFlipType imageOrientation = 0;
            int positionX = 0;
            int positionY = 0;
            

            foreach (var wallType in mapCaseTypeList)
            {
                switch (wallType)
                {
                    //Dead End
                    case "DE-S":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = RotateFlipType.RotateNoneFlipNone;
                        break;
                    case "DE-W":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = RotateFlipType.Rotate90FlipNone;
                        break;
                    case "DE-E":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = RotateFlipType.Rotate180FlipNone;
                        break;
                    case "DE-N":
                        imagePath = deadEndsAssetsPath;
                        imageOrientation = RotateFlipType.Rotate270FlipNone;
                        break;

                    //Corners
                    case "C-ES":
                        imagePath = cornersAssetsPath;
                        imageOrientation = RotateFlipType.RotateNoneFlipNone;
                        break;
                    case "C-SW":
                        imagePath = cornersAssetsPath;
                        imageOrientation = RotateFlipType.Rotate90FlipNone;
                        break;
                    case "C-NW":
                        imagePath = cornersAssetsPath;
                        imageOrientation = RotateFlipType.Rotate180FlipNone;
                        break;
                    case "C-NE":
                        imagePath = cornersAssetsPath;
                        imageOrientation = RotateFlipType.Rotate270FlipNone;
                        break;


                    //Corridors
                    case "CO-NS":
                        imagePath = corridorAssetsPath;
                        imageOrientation = RotateFlipType.RotateNoneFlipNone;
                        break;
                    case "CO-WE":
                        imagePath = corridorAssetsPath;
                        imageOrientation = RotateFlipType.Rotate90FlipNone;
                        break;

                    //T-Shaped
                    case "T-ESW":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = RotateFlipType.RotateNoneFlipNone;
                        break;
                    case "T-NSW":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = RotateFlipType.Rotate90FlipNone;
                        break;
                    case "T-NEW":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = RotateFlipType.Rotate180FlipNone;
                        break;
                    case "T-NES":
                        imagePath = tShapeAssetsPath;
                        imageOrientation = RotateFlipType.Rotate270FlipNone;
                        break;

                    //Crossway
                    case "CR":
                        imagePath = crossWayAssetsPath;
                        imageOrientation = RotateFlipType.RotateNoneFlipNone;
                        break;
                }
                
                Image image = new Bitmap($"{imagePath}\\50x50.bmp");
                Point destinationPoint = new Point(0, 0);
                drawingTools.DrawImage(image, destinationPoint);

                //Drawing the images on the map image
/*                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        image.RotateFlip(imageOrientation);
                        //draw the image where it should go

                        drawingTools.DrawImage(image, destinationPoint);
                        destinationPoint.X += image.Width;
                    }

                    destinationPoint.X = 0;
                    destinationPoint.Y += image.Width;
                }*/
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
            Point casePositionDraw = new Point();
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

                casePositionDraw = PointTranslation(wall.PosX, wall.PosY);
                mapCasePositions.Add(new Point(casePositionDraw.X,casePositionDraw.Y));
                mapCaseTypeList.Add(wallType);
            }
        }

        public Point PointTranslation(int posX, int posY)
        {
            Point point = new Point();
            point.X *= 50;
            point.Y *= 50;
            return point;
        }
    }
}
