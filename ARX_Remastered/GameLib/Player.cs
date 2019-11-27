using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Player
    {
        private string userName;
        private double lifePoint;
        private Position position;
        private Inventory inventory;

        public Player(string userName, double lifePoint, Position position, Inventory inventory)
        {
            this.userName = userName;
            this.lifePoint = lifePoint;
            this.position = position;
            this.inventory = inventory;
        }
        public Player(string userName, Position position, Inventory inventory)
        {
            this.userName = userName;
            this.lifePoint = 100;
            this.position = position;
            this.inventory = inventory;
        }
        public Player(string userName, Inventory inventory)
        {
            this.userName = userName;
            this.lifePoint = 100;
            this.position = position;
            this.inventory = inventory;
        }
        public Player(string userName)
        {
            this.userName = userName;
            this.lifePoint = 100;
            
        }
    }
}
