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
        private List<List<Case>> boardContent;

        public Board()
        {
            this.height = 10;
            this.width = 10;
            boardContent = new List<List<Case>>();
        }
        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
            boardContent = new List<List<Case>>();
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }

        public List<List<Case>> BoardContent
        {
            get { return boardContent; }
            set => boardContent = value;
        }
    }
}
