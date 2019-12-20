using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class BoardLine
    {
        private List<Case> lineContent;
        public BoardLine()
        {
            lineContent = new List<Case>();
        }

        public BoardLine(int size)
        {
            lineContent = new List<Case>(size);
        }

        public BoardLine(List<Case> content)
        {
            this.lineContent = content;
        }
        public List<Case> LineContent
        {
            get { return lineContent; }
            set { lineContent = value; }
        }
    }
}
