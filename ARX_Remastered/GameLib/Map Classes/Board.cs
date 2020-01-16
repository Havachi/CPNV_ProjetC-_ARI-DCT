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
            List<string> fileContent = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    foreach (var value in values)
                    {
                        fileContent.Add(value);
                    }
                }

                Case caseToAdd;
                foreach (var acase in fileContent)
                {
                    if (acase == "11")
                    {
                       
                    }
                    if (acase == "12")
                    {

                    }
                    if (acase == "13")
                    {

                    }
                    if (acase == "14")
                    {

                    }

                    if (acase == "21")
                    {

                    }
                    if (acase == "22")
                    {

                    }
                    if (acase == "23")
                    {

                    }
                    if (acase == "24")
                    {

                    }

                    if (acase == "31")
                    {

                    }
                    if (acase == "32")
                    {

                    }

                    if (acase == "41")
                    {

                    }

                    if (acase == "51")
                    {

                    }
                    if (acase == "52")
                    {

                    }
                    if (acase == "53")
                    {

                    }
                    if (acase == "54")
                    {

                    }
                    if (acase == "61")
                    {

                    }
                    if (acase == "71")
                    {

                    }
                    if (acase == "8")
                    {

                    }

                    if (acase == "9")
                    {
                        
                    }
                }

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
