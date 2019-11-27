using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Player
    {
        private string username;
        private double lifepoint;
        private Position position;
        private Inventory inventory;
        private string direction;

        public Player(string userName, double lifePoint, Position position, Inventory inventory, string direction)
        {
            this.username = userName;
            this.lifepoint = lifePoint;
            this.position = position;
            this.inventory = inventory;
            this.direction = direction;
        }
        public string Username
        {
            get { return username; }
        }
        public double Lifepoint
        {
            get
            {
                return lifepoint;
            }
        }
        public Position Position
        {
            get
            {
                return position;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }
        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
