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

        protected Case(int indexX, int indexY)
        {
            this.indexX = indexX;
            this.indexY = indexY;
        }
        protected Case(int indexX, int indexY, int orientation)
        {
            this.indexX = indexX;
            this.indexY = indexY;
            this.orientation = orientation;
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

