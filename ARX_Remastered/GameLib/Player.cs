using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Player
    {
        private string lifePoint;
        private string speedPoint;
        private Position position;
        private Inventory inventory;

        public Player(string lifePoint, string speedPoint, Position position, Inventory inventory)
        {
            this.lifePoint = lifePoint;
            this.speedPoint = speedPoint;
            this.position = position;
            this.inventory = inventory;
        }
    }
}
