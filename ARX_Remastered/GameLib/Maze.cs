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
        private int currentX = 0;
        private int currentY = 0;
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
        /// The Maximum of case that can be visited
        /// </summary>
        /// <remarks>
        /// Can't be > than maxHeight * maxWidth
        /// </remarks>
        private int MaxVisitedCase = 100;
        /// <summary>
        /// This list of int array contains all the position of the map.
        /// </summary>
        /// <remarks>
        /// The structure of each array of int should be {posX, posY, visited}
        /// </remarks>
        private List<Case> caseInfoList = new List<Case>();
        /// <summary>
        /// This list of array of bool contains information about the "walls"
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
        private Random rand;

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
            //The last X Position
            int lastX = 0;
            //The last Y Position
            int lastY = 0;
            //Sets the number of visited case to 0
            nbOfVisitedCase = 0;
            //The random number for the generation
            int r = 0;

            //Fullify the Maze with unvisited Case 
            for (int i = 0; i < maxWidth; i++)
            {
                for (int j = 0; j < maxHeight; j++)
                {
                    caseInfoList.Add(new Case(i,j,false));
                }
            }

            //Stack the Initial position in the stack
            mazeStack.Push(new Point(currentX, currentY));
            caseInfoList[0].Visited = true;
            nbOfVisitedCase++;
            
            //The do while end when all case are visited
            do
            {
                var currentCase = caseInfoList[0];
                var unvisitedCases = GetFourDirectionVisited(currentX,currentY);
                if (unvisitedCases.Count() != 0)
                {
                    lastX = currentX;
                    lastY = currentY;
                    rand = new Random();
                    r = rand.Next(0, unvisitedCases.Count-1);
                    
                    switch (r)
                    {
                        case 0:
                            currentX = unvisitedCases[0].PosX;
                            currentY = unvisitedCases[0].PosY;
                            mazeStack.Push(new Point(currentX, currentY));
                            break;
                        case 1:
                            currentX = unvisitedCases[1].PosX;
                            currentY = unvisitedCases[1].PosY;
                            mazeStack.Push(new Point(currentX, currentY));
                            break;
                        case 2:
                            currentX = unvisitedCases[2].PosX;
                            currentY = unvisitedCases[2].PosY;
                            mazeStack.Push(new Point(currentX, currentY));
                            break;
                        case 3:
                            currentX = unvisitedCases[3].PosX;
                            currentY = unvisitedCases[3].PosY;
                            mazeStack.Push(new Point(currentX, currentY));
                            break;
                    }
                    currentCase.PosX = currentX;
                    currentCase.PosY = currentY;
                    nbOfVisitedCase++;
                    caseInfoList[GetPositionInList(currentCase.PosX,currentCase.PosY)].Visited = true;

                }
                else
                {
                    Backtrack();
                }
                
            } while (nbOfVisitedCase != MaxVisitedCase);

            //This is just for debugging purpose
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\aled.txt", false))
            {
                int unvisitedCasesTotal = 0;
                int visitedCasesTotal = 0;
                foreach (var cacase in caseInfoList)
                {
                    if (cacase.Visited == false)
                    {
                        unvisitedCasesTotal++;
                    }
                    else
                    {
                        visitedCasesTotal++;
                    }
                }
                file.WriteLine($"Total :{nbOfVisitedCase} ");
                file.WriteLine($"Total Unvisited:{unvisitedCasesTotal} ");
                file.WriteLine($"Total Visited:{visitedCasesTotal} \n\n\n");
                
                foreach (var cacase in caseInfoList)
                {

                    if (cacase.PosX==9)
                    {
                        file.Write(!cacase.Visited ? "*\n" : "#\n");
                    }
                    else
                    {
                        file.Write(!cacase.Visited ? "*" : "#");
                    }

                    //file.WriteLine($"{cacase.PosX},{cacase.PosY},{cacase.Visited}");
                }
            }
        }

        /// <summary>
        /// This method check if the case is already visited
        /// </summary>
        public bool IsAlreadyVisited(int posX, int posY)
        {
            var c = new Case(posX,posY,true);
            if (caseInfoList.Contains(c))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// This method is used by the algorithm when in an dead-end
        /// </summary>
        public void Backtrack()
        {
            var actualPoint = new Point();
            var listOfUnvisitedCases = new List<Case>();
            do
            {
                actualPoint = mazeStack.Pop();
                listOfUnvisitedCases = GetFourDirectionVisited(actualPoint.X, actualPoint.Y);

            } while (listOfUnvisitedCases != null);
            currentX = actualPoint.X;
            currentY = actualPoint.Y;
        }

        
        /// <summary>
        /// This method check in the 4 direction to see if the case has already been visited
        /// </summary>
        public List<Case> GetFourDirectionVisited(int posX, int posY)
        {

            var caseToSearch = new Case(posX,posY);

            Case caseToSearchRight;
            Case caseToSearchUp;
            Case caseToSearchBottom;
            Case caseToSearchLeft;

            var listOfUnvisited = new List<Case>();

            //if in top left corner
            if (currentX == 0 && currentY == 0)
            {
                caseToSearchRight = new Case(posX + 1, posY);
                caseToSearchBottom = new Case(posX, posY + 1);
                //right
                if (caseInfoList[GetPositionInList(caseToSearchRight.PosX, caseToSearchRight.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchRight);
                }
                //down
                if (caseInfoList[GetPositionInList(caseToSearchBottom.PosX, caseToSearchBottom.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchBottom);
                }
            }
            //if in top right corner
            else if (currentX == maxWidth - 1 && currentY == 0)
            {
                caseToSearchLeft = new Case(posX - 1, posY);
                caseToSearchBottom = new Case(posX, posY + 1);
                //down
                if (caseInfoList[GetPositionInList(caseToSearchBottom.PosX, caseToSearchBottom.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchBottom);
                }

                //left
                if (caseInfoList[GetPositionInList(caseToSearchLeft.PosX, caseToSearchLeft.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchLeft);
                }

            }
            //if in bottom right corner
            else if (currentX == maxWidth - 1 && currentY == maxHeight - 1)
            {
                caseToSearchUp = new Case(posX, posY - 1);
                //up
                if (caseInfoList[GetPositionInList(caseToSearchUp.PosX, caseToSearchUp.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchUp);
                }
                caseToSearchLeft = new Case(posX - 1, posY);
                //left
                if (caseInfoList[GetPositionInList(caseToSearchLeft.PosX, caseToSearchLeft.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchLeft);
                }

            }
            //if in bottom left corner
            else if (currentX == 0 && currentY == maxHeight - 1)
            {
                caseToSearchRight = new Case(posX + 1, posY);
                caseToSearchUp = new Case(posX, posY - 1);
                //up
                if (caseInfoList[GetPositionInList(caseToSearchUp.PosX, caseToSearchUp.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchUp);
                }
                //right
                if (caseInfoList[GetPositionInList(caseToSearchRight.PosX, caseToSearchRight.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchRight);
                }
            }
            //if on left border
            else if (currentX == 0)
            {
                caseToSearchRight = new Case(posX + 1, posY);
                caseToSearchUp = new Case(posX, posY - 1);
                caseToSearchBottom = new Case(posX, posY + 1);
                //up
                if (caseInfoList[GetPositionInList(caseToSearchUp.PosX, caseToSearchUp.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchUp);
                }

                //right
                if (caseInfoList[GetPositionInList(caseToSearchRight.PosX, caseToSearchRight.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchRight);
                }
                //down
                if (caseInfoList[GetPositionInList(caseToSearchBottom.PosX, caseToSearchBottom.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchBottom);
                }
            }
            //if on top border
            else if (currentY == 0)
            {
                caseToSearchRight = new Case(posX + 1, posY);
                caseToSearchBottom = new Case(posX, posY + 1);
                caseToSearchLeft = new Case(posX - 1, posY);
                //left
                if (caseInfoList[GetPositionInList(caseToSearchLeft.PosX, caseToSearchLeft.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchLeft);
                }
                //right
                if (caseInfoList[GetPositionInList(caseToSearchRight.PosX, caseToSearchRight.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchRight);
                }
                //down
                if (caseInfoList[GetPositionInList(caseToSearchBottom.PosX, caseToSearchBottom.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchBottom);
                }
            }
            //if on right border
            else if (currentX == maxWidth - 1)
            {
                caseToSearchUp = new Case(posX, posY - 1);
                caseToSearchBottom = new Case(posX, posY + 1);
                caseToSearchLeft = new Case(posX - 1, posY);
                //up
                if (caseInfoList[GetPositionInList(caseToSearchUp.PosX, caseToSearchUp.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchUp);
                }
                //left
                if (caseInfoList[GetPositionInList(caseToSearchLeft.PosX, caseToSearchLeft.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchLeft);
                }
                //down
                if (caseInfoList[GetPositionInList(caseToSearchBottom.PosX, caseToSearchBottom.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchBottom);
                }
            }
            //if on bottom border
            else if (currentY == maxHeight - 1)
            {
                caseToSearchRight = new Case(posX + 1, posY);
                caseToSearchUp = new Case(posX, posY - 1);
                caseToSearchLeft = new Case(posX - 1, posY);
                //up
                if (caseInfoList[GetPositionInList(caseToSearchUp.PosX, caseToSearchUp.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchUp);
                }
                //left
                if (caseInfoList[GetPositionInList(caseToSearchLeft.PosX, caseToSearchLeft.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchLeft);
                }
                //right
                if (caseInfoList[GetPositionInList(caseToSearchRight.PosX, caseToSearchRight.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchRight);
                }
            }
            //if not on any border
            else
            {
                caseToSearchRight = new Case(posX + 1, posY);
                caseToSearchUp = new Case(posX, posY - 1);
                caseToSearchBottom = new Case(posX, posY + 1);
                caseToSearchLeft = new Case(posX - 1, posY);
                //up
                if (caseInfoList[GetPositionInList(caseToSearchUp.PosX, caseToSearchUp.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchUp);
                }
                //left
                if (caseInfoList[GetPositionInList(caseToSearchLeft.PosX, caseToSearchLeft.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchLeft);
                }
                //right
                if (caseInfoList[GetPositionInList(caseToSearchRight.PosX, caseToSearchRight.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchRight);
                }
                //down
                if (caseInfoList[GetPositionInList(caseToSearchBottom.PosX, caseToSearchBottom.PosY)].Visited == false)
                {
                    listOfUnvisited.Add(caseToSearchBottom);
                }
            }
            return listOfUnvisited;
        }

        public int GetPositionInList(int posX,int posY)
        {
            int positionInList = -1;
            if (posY == 0)
            {
                if (posX == 0)
                {
                    positionInList = 0;
                }

                positionInList = posX;
            }
            if (posY > 0)
            {
                positionInList = (posY * 10) + posX;
            }
            return positionInList;
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

    }
}
