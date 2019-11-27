using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Movement
    {
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
        public void Turn(Player player, string turnDirection)
        {
            if (player.Direction == "N" && turnDirection == "left")
            {
                player.Direction = "W";             
            }
            if (player.Direction == "N" && turnDirection == "right")
            {
                player.Direction = "E";
            }


            if (player.Direction == "E" && turnDirection == "left")
            {
                player.Direction = "S";
            }
            if (player.Direction == "E" && turnDirection == "right")
            {
                player.Direction = "N";
            }


            if (player.Direction == "S" && turnDirection == "left")
            {
                player.Direction = "E";
            }
            if (player.Direction == "S" && turnDirection == "right")
            {
                player.Direction = "W";
            }


            if (player.Direction == "W" && turnDirection == "left")
            {
                player.Direction = "S";
            }
            if (player.Direction == "W" && turnDirection == "right")
            {
                player.Direction = "N";
            }
        }
        public void Teleport(Player player, int newPosX, int newPosY)
        {
            player.Position.PositionX = newPosX;
            player.Position.PositionY = newPosY;

        }
    }
}
