using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameLib
{

    /// <summary>
    /// This method contains method for generating new level.
    /// </summary>
    public class Maze
    {
        /// <summary>
        /// The maximum height of the map.
        /// </summary>
        private int maxHeight = 10;
        /// <summary>
        /// The maximum width of the map.
        /// </summary>
        private int maxWidth = 10;
        /// <summary>
        /// The number case that as already been visited by the algorithm (max = max width * max height)
        /// </summary>
        private int nbOfVisitedCase = 0;
        /// <summary>
        /// This list of int array contains all the position of the map.
        /// </summary>
        /// <remarks>
        /// The structure of each array of int should be {posX, posY, visited}
        /// </remarks>
        private List<int[]> caseInfoList = new List<int[]>();
        /// <summary>
        /// This list of array of bool contains infomation about the "walls"
        /// </summary>
        /// <remarks>
        /// The structure of the array of bool should be {wallN, wallE, wallS, wallW}
        /// </remarks>
        private List<bool[]> caseNearInfo = new List<bool[]>();
        /// <summary>
        /// This Stack of Point is used by the algorithm to temporary stock position coordinate.
        /// </summary>
        /// <remarks>
        /// This is used for backtracking because stack have the particularity of Last In, First Out.
        /// </remarks>
        private Stack<Point> mazeStack=new Stack<Point>();

        /// <summary>
        ///  Random number.
        /// </summary>
        Random rand = new Random();

        /// <summary>
        /// This is the main part of the algorithm,
        /// the part that create new path,
        /// It use other method for backtracking and choosing a new way.
        /// </summary>
        /// <remarks>
        /// The algorithm work like this:
        /// - todo First We choose a start point randomly on the map.
        /// - todo Then the algorithm choose between all unvisited case around him
        /// - todo Then the algorithm stack the last position in <c>mazeStack</c>
        /// - todo Then the algorithm write the last position and the set the visited case in <c>caseInfoList</c>
        /// - todo Then it continue until the maximum possible number of case are visited (MaxHeight * MaxWidth),
        /// - todo We could also choose a number of void case to regulate the difficulty (More void case, less possible way)
        /// - todo When the maximum void case is reached, the wall calculating process begin <see cref=""/>
        /// </remarks>
        public void GenerateMaze()
        {

            int currentX = 0;
            int currentY = 0;
            int lastX = 0;
            int lastY = 0;
            int tempX;
            int tempY;
            mazeStack.Push(new Point(currentX, currentY));
            nbOfVisitedCase++;

            do
            {
                if (currentX > 0 || currentY > 0)
                {
                    mazeStack.Push(new Point(currentX, currentY));
                    nbOfVisitedCase++;
                    var r = 0;
                    caseInfoList.Add(new int[] { currentX, currentY });
                    if (lastY < currentY)
                    {
                        caseNearInfo.Add(new bool[] { true, false, false, true });
                    }
                    else if(lastX < currentX)
                    {
                        caseNearInfo.Add(new bool[] { true, false, false, true });
                    }
                    
                    if (currentY == 0)
                    {
                        do
                        {
                            r = rand.Next(0, 3);
                        } while (r == 0);
                    }
                    else if (currentX == 0)
                    {
                        do
                        {
                            r = rand.Next(0, 3);
                        } while (r == 4);
                    }

                    switch (r)
                    {
                        case 0:
                            lastY = currentY;
                            currentY--;
                            break;
                        case 1:
                            lastX = currentX;
                            currentX++;
                            break;
                        case 2:
                            lastY = currentY;
                            currentY++;
                            break;
                        case 3:
                            lastX = currentX;
                            currentX--;
                            break;
                    }

                }
                else if(currentY == 0 && currentX == 0)
                {
                    //Store the current position in the maze and in the order of visit
                    caseInfoList.Add(new int[] { currentX, currentY});
                    //Is true if there is a wall on that direction. False if not
                    caseNearInfo.Add(new bool[] { true, false, false, true });
                    mazeStack.Push(new Point(currentX, currentY));
                    lastX = currentX;
                    lastY = currentY;

                    if (rand.Next(0, 1) == 0)
                    {
                        currentX++;
                    }
                    else
                    {
                        currentY++;
                    }
                    nbOfVisitedCase++;
                }
            } while (nbOfVisitedCase != maxWidth * maxHeight);
        }

        public bool IsAlreadyVisited(List<int[]> gridList, int currentX, int currentY)
        {
            gridList.Reverse();
            foreach (int[] caseInfo in gridList)
            {
                if (currentX.Equals(caseInfo[0]) && currentY.Equals(caseInfo[1]))
                {
                    return true;
                }
            }
            return false;
        }

        public void BacktrackUntilUnvisited()
        {

        }

        public void BacktrackStep()
        {

        }

        public void CheckFourDirectionVisited() 
        {

        }
        
        /// <summary>
        /// This is the algorithm part were wall are calculated.
        /// </summary>
        /// <remarks>
        /// The Wall Calculation goes like that:
        /// - todo First the mazeStack Stack variable is used in a step by step backtrack method, not the BacktrackUntilUnvisited() method
        /// - todo Then walls are placed if there is no direct link between case if there is a direct link, no wall are placed
        /// </remarks>
        public void WallCalculation()
        {
             
        }
        public List<int[]> CaseInfoList
        {
            get { return caseInfoList; }
        }
    }
}
