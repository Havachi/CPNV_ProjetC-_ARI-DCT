using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameLib
{
    public class Maze
    {
        private int maxHeight = 10;
        private int maxWidth = 10;
        private int nbOfVisitedCase = 0;
        
        private List<int[]> caseInfoList = new List<int[]>();
        private List<bool[]> caseNearInfo = new List<bool[]>();
        private Stack<Point> mazeStack=new Stack<Point>();
        Random rand = new Random();
        

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

        public void Backtrack(Stack<Point> stack, List<int[]> gridList)
        {

            Point backPoint = stack.Pop();
            var xValue = backPoint.X;
            var yValue = backPoint.Y;
            foreach (var gridInfo in gridList)
            {
                if (gridInfo[0] == xValue+1)
                {
                    
                }
            }
        }

        public void CheckFourDirectionVisited() 
        {

        }

        public List<int[]> CaseInfoList
        {
            get { return caseInfoList; }
        }
    }
}
