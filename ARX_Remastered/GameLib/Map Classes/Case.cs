using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Case
    {
        private int posX;
        private int posY;
        private bool visited;
        public Case(int posX,int posY, bool visited = false)
        {
            this.posX = posX;
            this.posY = posY;
            this.visited = visited;
        }

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }
        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
    }

    public class VoidCase : Case
    {
        private int posX;
        private int posY;
        private bool visited;

        public VoidCase(int posX, int posY, bool visited) : base(posX, posY, visited)
        {
            this.posX = posX;
            this.posY = posY;
            this.visited = visited;
        }
    }
    public class TerrainCase : Case
    {
        private int posX;
        private int posY;
        private bool visited;
        public TerrainCase(int posX, int posY, bool visited) : base(posX, posY, visited)
        {
            this.posX = posX;
            this.posY = posY;
            this.visited = visited;
        }
    }

}

