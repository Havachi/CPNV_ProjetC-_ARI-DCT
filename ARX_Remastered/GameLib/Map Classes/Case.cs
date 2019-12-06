using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Case
    {

    }

    public class VoidCase : Case
    {
        
        public VoidCase() : base()
        {
            
        }
    }
    public class TerrainCase : Case
    {
        protected string orientation;
        protected bool wallNorth = false;
        protected bool wallEast = false;
        protected bool wallSouth = false;
        protected bool wallWest = false;
        public TerrainCase(string orientation)
        {
            this.orientation = orientation;
        }
    }

    public class DeadEndTerrainCase : TerrainCase
    {
        public DeadEndTerrainCase(string orientation) : base(orientation)
        {
            this.orientation = orientation;
        }
    }
    public class CornerCase : TerrainCase
    {
        public CornerCase(string orientation) : base(orientation)
        {
            this.orientation = orientation;
        }
    }

    public class CorridorCase : TerrainCase
    {
        public CorridorCase(string orientation) : base(orientation)
        {
            this.orientation = orientation;
        }
    }

    public class TShapeCase : TerrainCase
    {
        public TShapeCase(string orientation) : base(orientation)
        {
            this.orientation = orientation;
        }
    }
}

