using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    /// <summary>
    /// This Class contain method for creating and setup Player in the game
    /// </summary>
    public class Player
    {
        
        private string username;
        private double lifepoint;
        private Position position;
        private Inventory inventory;
        private string direction;

        /// <summary>
        /// Constructor for the player object
        /// </summary>
        /// <param name="username">This is the player username (from DB)</param>
        /// <param name="lifePoint">This is the player lifeppoint (might not be used)</param>
        /// <param name="position">This is the player current position (X and Y)</param>
        /// <param name="inventory">This is the player inventory</param>
        /// <param name="direction">This is the current player orientation (N,E,S,W)</param>
        public Player(string username, double lifePoint, Position position, Inventory inventory, string direction)
        {
            this.username = username;
            this.lifepoint = lifePoint;
            this.position = position;
            this.inventory = inventory;
            this.direction = direction;
        }
        /// <summary>
        /// Accessor for private attribut username
        /// </summary>
        public string Username
        {
            get { return username; }
        }
        /// <summary>
        /// Accessor for private attribut lifepoint
        /// </summary>
        public double Lifepoint
        {
            get
            {
                return lifepoint;
            }
        }
        /// <summary>
        /// Accessor for private attribut position
        /// </summary>
        public Position Position
        {
            get
            {
                return position;
            }
        }
        /// <summary>
        /// Accessor for private attribut inventory
        /// </summary>
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }
        /// <summary>
        /// Accessor for private attribut dirention
        /// </summary>
        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
