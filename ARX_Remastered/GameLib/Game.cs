using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLib
{
    public class Game
    {
        private Player player;
        private Map map;


        public Game(Player player, Map map)
        {
            this.player = player;
            this.map = map;
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
