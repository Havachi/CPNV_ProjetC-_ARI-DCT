using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{

    public enum Direction
    {
        Null = -1,
        Up = 0,
        Right = 90,
        Down = 180,
        Left = 270
    }
    public enum State
    {
        Void = 0,
        DeadEnd = 1,
        Corner = 2,
        TShape = 3,
        CrossWay = 4,
        Wall = 5,
        Corridor = 6

    }

    public class Case
    {
        private int indexX;
        private int indexY;
        private State state;
        private Direction direction;

        public Case(int indexX, int indexY,State state = State.Void, Direction direction = Direction.Null)
        {
            this.indexX = indexX;
            this.indexY = indexY;
            this.state = state;
            this.direction = direction;
        }
        public Case(State state = State.Void, Direction direction = Direction.Null)
        {
            this.state = state;
            this.direction = direction;
        }
        public Case()
        {

        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public State State
        {
            get { return state; }
            set { state = value; }
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
    }
    /// <summary>
    /// Represent an empty case
    /// </summary>
    public class VoidCase : Case
    { 

        public VoidCase(int indexX,int indexY) : base(indexX,indexY)
        {
            this.IndexX = indexX;
            this.IndexY = indexX;
        }
    }
    /// <summary>
    /// Represent a case where the player can pass
    /// </summary>
    public class TerrainCase : Case
    {
        public TerrainCase(State state, Direction direction) : base()
        {

        }
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
        public WallCase() : base()
        {
            State = State.Wall;
        }
    }
    

}

