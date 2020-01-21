using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{

    public abstract class Case
    {
        protected int indexX;
        protected int indexY;
        protected int orientation;
        protected bool[] walls;

        protected Case(int indexX, int indexY)
        {
            this.indexX = indexX;
            this.indexY = indexY;
            walls = new bool[4];
        }
        protected Case(int indexX, int indexY, int orientation)
        {
            this.indexX = indexX;
            this.indexY = indexY;
            this.orientation = orientation;
            walls = new bool[4];
        }

        public int TypeToInt()
        {
            if (GetType() == typeof(CornerCase))
            {
                return 1;
            }
            if (GetType() == typeof(DeadEnd))
            {
                return 2;
            }
            if (GetType() == typeof(CrosswayCase))
            {
                return 3;
            }
            if (GetType() == typeof(CorridorCase))
            {
                return 4;
            }
            if (GetType() == typeof(TShapeCase))
            {
                return 5;
            }
            

            return 0;
        }

        public string TypeToString()
        {
            if (GetType() == typeof(CornerCase))
            {
                return "CO";
            }
            if (GetType() == typeof(DeadEnd))
            {
                return "DE";
            }
            if (GetType() == typeof(CrosswayCase))
            {
                return "X";
            }
            if (GetType() == typeof(CorridorCase))
            {
                return "C";
            }
            if (GetType() == typeof(TShapeCase))
            {
                return "T";
            }

            if (GetType() == typeof(StartCase))
            {
                return "S";
            }
            if (GetType() == typeof(EndCase))
            {
                return "E";
            }

            return "V";
        }
        public void AssignWall()
        {
            if (GetType() == typeof(CornerCase))
            {
                switch (Orientation)
                {
                    case 1:
                        walls[0] = true;
                        walls[1] = false;
                        walls[2] = false;
                        walls[3] = true;
                        break;
                    case 2:
                        walls[0] = true;
                        walls[1] = true;
                        walls[2] = false;
                        walls[3] = false;
                        break;
                    case 3:
                        walls[0] = false;
                        walls[1] = true;
                        walls[2] = true;
                        walls[3] = false;
                        break;
                    case 4:
                        walls[0] = false;
                        walls[1] = false;
                        walls[2] = true;
                        walls[3] = true;
                        break;
                }
            }
            if (GetType() == typeof(DeadEnd))
            {
                switch (Orientation)
                {
                    case 1:
                        walls[0] = true;
                        walls[1] = true;
                        walls[2] = false;
                        walls[3] = true;
                        break;
                    case 2:
                        walls[0] = true;
                        walls[1] = true;
                        walls[2] = true;
                        walls[3] = false;
                        break;
                    case 3:
                        walls[0] = false;
                        walls[1] = true;
                        walls[2] = true;
                        walls[3] = true;
                        break;
                    case 4:
                        walls[0] = true;
                        walls[1] = false;
                        walls[2] = true;
                        walls[3] = true;
                        break;
                }
            }
            if (GetType() == typeof(CrosswayCase))
            {
                switch (Orientation)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        walls[0] = false;
                        walls[1] = false;
                        walls[2] = false;
                        walls[3] = false;
                        break;
                }
            }
            if (GetType() == typeof(TShapeCase))
            {
                switch (Orientation)
                {
                    case 1:
                        walls[0] = true;
                        walls[1] = false;
                        walls[2] = false;
                        walls[3] = false;
                        break;
                    case 2:
                        walls[0] = false;
                        walls[1] = true;
                        walls[2] = false;
                        walls[3] = false;
                        break;
                    case 3:
                        walls[0] = false;
                        walls[1] = false;
                        walls[2] = true;
                        walls[3] = false;
                        break;
                    case 4:
                        walls[0] = false;
                        walls[1] = false;
                        walls[2] = false;
                        walls[3] = true;
                        break;
                }
            }
            if (GetType() == typeof(CorridorCase))
            {
                switch (Orientation)
                {
                    case 1:
                        walls[0] = false;
                        walls[1] = true;
                        walls[2] = false;
                        walls[3] = true;
                        break;
                    case 2:
                        walls[0] = true;
                        walls[1] = false;
                        walls[2] = true;
                        walls[3] = false;
                        break;

                }
            }
            if (GetType() == typeof(StartCase))
            {
                walls[0] = false;
                walls[1] = false;
                walls[2] = false;
                walls[3] = false;
            }
            if (GetType() == typeof(EndCase))
            {
                walls[0] = false;
                walls[1] = false;
                walls[2] = false;
                walls[3] = false;
            }
            if (GetType() == typeof(VoidCase))
            {
                walls[0] = true;
                walls[1] = true;
                walls[2] = true;
                walls[3] = true;
            }
        }
        public int IndexX
        {
            get { return indexX; }
            set { indexX = value; }
        }
        public int IndexY
        {
            get { return indexY; }
            set { indexY = value; }
        }
        public int Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        public bool[] Walls
        {
            get { return walls; }
            set { walls = value; }
        }
    }
    
    /// <summary>
    /// Represent an empty case
    /// </summary>
    public class VoidCase : Case
    {
        public VoidCase(int indexX,int indexY) : base(indexX,indexY)
        {
            this.indexX = indexX;
            this.indexY = indexY;
        }
    }

    /// <summary>
    /// Represent a case that is a wall
    /// </summary>
    public class WallCase : Case
    {
        public WallCase(int indexX, int indexY) : base(indexX, indexY)
        {
            this.indexX = indexX;
            this.indexY = indexY;
        }
    }
    /// <summary>
    /// Represent a case where the player can pass
    /// </summary>
    public class TerrainCase : Case
    {
        public TerrainCase(int indexX, int indexY, int orientation) : base(indexX, indexY, orientation)
        {

        }
    }

    public class DeadEnd : TerrainCase
    {
        public DeadEnd(int indexX, int indexY, int orientation) : base(indexX, indexY, orientation)
        {

        }
    }

    public class CorridorCase : TerrainCase
    {
        public CorridorCase(int indexX, int indexY, int orientation) : base(indexX, indexY,orientation)
        {

        }
    }
    public class CornerCase : TerrainCase
    {
        public CornerCase(int indexX, int indexY, int orientation) : base(indexX, indexY,orientation)
        {

        }
    }

    public class TShapeCase : TerrainCase
    {
        public TShapeCase(int indexX, int indexY, int orientation) : base(indexX, indexY, orientation)
        {

        }
    }

    public class CrosswayCase : TerrainCase
    {
        public CrosswayCase(int indexX, int indexY, int orientation) : base(indexX, indexY, orientation)
        {

        }
    }


    public class StartCase : TerrainCase
    {
        public StartCase(int indexX, int indexY, int orientation) : base(indexX, indexY, orientation)
        {

        }
    }
    public class EndCase : TerrainCase
    {
        public EndCase(int indexX, int indexY, int orientation) : base(indexX, indexY, orientation)
        {

        }
    }
}

