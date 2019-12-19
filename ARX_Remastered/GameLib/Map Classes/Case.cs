using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{

    public class Case
    {
        public Case()
        {
    
        }

    }
    /// <summary>
    /// Represent an empty case
    /// </summary>
    public class VoidCase : Case
    {
        public VoidCase() : base()
        {

        }
    }
    /// <summary>
    /// Represent a case where the player can pass
    /// </summary>
    public class TerrainCase : Case
    {
        public TerrainCase() : base()
        {

        }
    }
    /// <summary>
    /// Represent a case that is a wall
    /// </summary>
    public class WallCase : Case
    {
        public WallCase() : base()
        {

        }
    }

}

