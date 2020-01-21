using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Board
    {
        private int height;
        private int width;
        private List<BoardLine> boardContent;

        private Position startPosition;
        private Position endPosition;

        public Board()
        {
            this.height = 10;
            this.width = 10;
            boardContent = new List<BoardLine>(height);
        }

        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
            boardContent = new List<BoardLine>(height);
        }

        public void FromFile(string path)
        {
            int indexX = 0;
            int indexY = 0;

            List<List<string>> fileContent = new List<List<string>>();
            List<string> fileLine = new List<string>();


            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    foreach (var value in values)
                    {
                        fileLine.Add(value);
                    }

                    fileContent.Add(fileLine);
                    fileLine = new List<string>();
                }
            }

            BoardLine tempBoardLine = new BoardLine();

                foreach (var line in fileContent)
                {
                    foreach (var acase in line)
                    {
                        Case caseToAdd = new VoidCase(indexX,indexY);
                        switch (acase)
                        {
                            case "11":
                                caseToAdd = new CornerCase(indexX, indexY, 1);
                                break;
                            case "12":
                                caseToAdd = new CornerCase(indexX, indexY, 2);
                                break;
                            case "13":
                                caseToAdd = new CornerCase(indexX, indexY, 3);
                                break;
                            case "14":
                                caseToAdd = new CornerCase(indexX, indexY, 4);
                                break;
                            case "21":
                                caseToAdd = new DeadEnd(indexX, indexY, 1);
                                break;
                            case "22":
                                caseToAdd = new DeadEnd(indexX, indexY, 2);
                                break;
                            case "23":
                                caseToAdd = new DeadEnd(indexX, indexY, 3);
                                break;
                            case "24":
                                caseToAdd = new DeadEnd(indexX, indexY, 4);
                                break;
                            case "31":
                                caseToAdd = new CorridorCase(indexX, indexY, 1);
                                break;
                            case "32":
                                caseToAdd = new CorridorCase(indexX, indexY, 2);
                                break;
                            case "41":
                                caseToAdd = new CrosswayCase(indexX, indexY, 1);
                                break;
                            case "51":
                                caseToAdd = new TShapeCase(indexX, indexY, 1);
                                break;
                            case "52":
                                caseToAdd = new TShapeCase(indexX, indexY, 2);
                                break;
                            case "53":
                                caseToAdd = new TShapeCase(indexX, indexY, 3);
                                break;
                            case "54":
                                caseToAdd = new TShapeCase(indexX, indexY, 4);
                                break;
                            case "61":
                                caseToAdd = new VoidCase(indexX, indexY);
                                break;
                            case "71":
                                caseToAdd = new WallCase(indexX, indexY);
                                break;
                            case "8":
                                caseToAdd = new StartCase(indexX, indexY, 1);
                                break;
                            case "9":
                                caseToAdd = new EndCase(indexX, indexY, 1);
                                break;

                               
                        }
                        caseToAdd.AssignWall();
                        tempBoardLine.AddCase(caseToAdd);
                        indexX++;
                    }
                    this.AddLine(tempBoardLine);
                    tempBoardLine = new BoardLine();
                    indexX = 0;
                    indexY++;
                }

            
        }
        public void AddLine(BoardLine boardLine)
        {
            boardContent.Add(boardLine);
        }

        public int Count(int typeOfCount = 0)
        {
            int count = 0;
            
            //count the number of case, default case
            if (typeOfCount == 0)
            {
                foreach (var boardLine in BoardContent)
                {
                    foreach (var aCase in boardLine.LineContent)
                    {
                        count++;
                    }
                }
            }
            //count the number of visited cases
            else if (typeOfCount == 1)
            {
                foreach (var boardLine in BoardContent)
                {
                    foreach (var aCase in boardLine.LineContent)
                    {
                        if (aCase.GetType() != typeof(VoidCase))
                        {
                            count++;
                        }
                    }
                }
            }
            //count the number of unvisited cases
            else if (typeOfCount == 2)
            {
                foreach (var boardLine in BoardContent)
                {
                    foreach (var aCase in boardLine.LineContent)
                    {
                        if (aCase.GetType() == typeof(VoidCase))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public bool ContainVoid()
        {
            foreach (var boardLine in BoardContent)
            {
                foreach (var aCase in boardLine.LineContent)
                {
                    if (aCase.GetType() == typeof(VoidCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }

        public List<BoardLine> BoardContent
        {
            get { return boardContent; }
            set { boardContent = value; } 
        }
        public Position StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }
        public Position EndPosition
        {
            get { return endPosition; }
            set { endPosition = value; }
        }
    }
}
