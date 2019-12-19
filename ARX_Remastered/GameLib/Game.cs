using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLib
{
    /// <summary>
    /// This class organize the game and call method to generate maps
    /// </summary>
    public class Game
    {
        private Player player;
        private Map map;

        /// <summary>
        /// Empty constructor used when no player exists
        /// </summary>
        public Game()
        {
            //player = new Player();
            map = new Map();
        }
        /// <summary>
        /// Constructor for games used when the player already exist
        /// </summary>
        public Game(Player player)
        {
            this.player = player;
            map = new Map();
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public Map Map
        {
            get { return map; }
            set { map = value; }
        }

    }
}
