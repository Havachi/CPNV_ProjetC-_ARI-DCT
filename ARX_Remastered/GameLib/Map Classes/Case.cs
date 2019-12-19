using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{

    public class Case
    {
        private Color caseColor;
        public Case()
        {
            caseColor = Color.White;
        }

    }
    /// <summary>
    /// Represent an empty case
    /// </summary>
    public class VoidCase : Case
    {
        private Color caseColor;
        public VoidCase() : base()
        {
            caseColor = Color.Yellow;
        }
    }
    /// <summary>
    /// Represent a case where the player can pass
    /// </summary>
    public class TerrainCase : Case
    {
        private Color caseColor;
        public TerrainCase() : base()
        {
            caseColor = Color.Red;
        }
    }
    /// <summary>
    /// Represent a case that is a wall
    /// </summary>
    public class WallCase : Case
    {
        private Color caseColor;
        public WallCase() : base()
        {
            caseColor = Color.Black;
        }
    }

}

