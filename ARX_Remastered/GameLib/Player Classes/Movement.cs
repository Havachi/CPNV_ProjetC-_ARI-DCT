using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    /// <summary>
    /// This class contain all method for moving, turning or teleporting the player
    /// </summary>
    public class Movement
    {
        /// <summary>
        /// This method is used to change player position in X and Y axis
        /// by 1 depending of the current orentation
        /// </summary>
        /// <param name="player">The player object</param>
        public void Move(Player player)
        {
            string direction = player.Direction;

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
        /// <summary>
        /// This method is used to change the player orientation depending of
        /// the actual orientation and if either the right or left key is pressed
        /// </summary>
        /// <param name="player">The player objet</param>
        /// <param name="turnDirection">The direction of the turn (left or right)</param> 
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
        /// <summary>
        /// This method is used to teleport the player across the map
        /// </summary>
        /// <param name="player">The player objet to teleport</param>
        /// <param name="newPosX">The new X coordinate</param>
        /// <param name="newPosY">The new Y coordinate</param>
        public void Teleport(Player player, int newPosX, int newPosY)
        {
            player.Position.PositionX = newPosX;
            player.Position.PositionY = newPosY;
        }
    }
}
