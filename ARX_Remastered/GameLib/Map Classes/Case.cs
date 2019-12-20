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
        public Case()
        {
        }
    }
    /// <summary>
    /// Represent an empty case
    /// </summary>
    public class VoidCase : Case
    {
        private Brush caseColor;
        public VoidCase() : base()
        {
            caseColor = Brushes.Yellow;
        }
        public Brush CaseColor
        {
            get { return caseColor; }
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

    public class StartCase : TerrainCase
    {
        public StartCase() : base()
        {

        }
    }
    public class EndCase : TerrainCase
    {
        public EndCase() : base()
        {

        }
    }

    /// <summary>
    /// Represent a case that is a wall
    /// </summary>
    public class WallCase : Case
    {
        private Brush caseColor;
        public WallCase() : base()
        {
            caseColor = Brushes.Black;
        }
        public Brush CaseColor
        {
            get { return caseColor; }
        }
    }

}

