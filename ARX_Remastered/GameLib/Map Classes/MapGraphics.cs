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
        private List<string> mapCaseTypeList = new List<string>();
        private List<Point> mapCasePositions = new List<Point>();
        private List<Bitmap> mapGraphicsList = new List<Bitmap>();
        private List<Wall> wallsInfoList = new List<Wall>();
        private Bitmap corner = new Bitmap(@"..\Assets\Map\Corner");


        private static int maxHeight = 10;
        private static int maxWidth = 10;
        private int caseToDraw = maxHeight * maxWidth;


        public void DrawMap(List<Wall> fullWallsList)
        {
            DetermineCaseType();
            //todo foreach type of wall assign a position, and an  orientation
            //todo draw one-by-one each entry in mapGraphicslist on an .bmp
            //todo save everything
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
