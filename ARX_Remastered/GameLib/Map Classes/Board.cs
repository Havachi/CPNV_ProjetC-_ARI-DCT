using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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

    }
}
