using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Movement
    {
        private string direction;
        

        public Movement(string direction)
        {
            this.direction = direction;
        }

        public void Move(Player player,string direction)
        {
            switch (direction)
            {           
                case "N":
                    player.Position.PositionY -= 1;
                    break;
                case "E":
                    player.Position.PositionX += 1;
                    break;
                case "S":
                    player.Position.PositionY += 1;
                    break;
                case "W":
                    player.Position.PositionX -= 1;
                    break;
            }
            
        }

    }
}
