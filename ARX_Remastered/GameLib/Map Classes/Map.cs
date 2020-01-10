using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace GameLib
{
    /// <summary>
    /// This class is the Coordinator for the map generation
    /// </summary>
    public class Map
    {
        private MapGenerator mapGenerator;
        private MapDrawer mapDrawer;
        private Board gameBoard;
        private bool randomGeneration = false;
        public Map()
        {
            mapGenerator = new MapGenerator(randomGeneration);
            mapDrawer = new MapDrawer(mapGenerator.Board);
            gameBoard = mapGenerator.Board;
        }

        public Map(bool randomGeneration)
        {
            mapGenerator = new MapGenerator(randomGeneration);
            mapDrawer = new MapDrawer(mapGenerator.Board);
            gameBoard = mapGenerator.Board;
        }

        public Map(int mapMaxHeight, int mapMaxWidth)
        {
            mapGenerator = new MapGenerator(mapMaxHeight, mapMaxWidth, randomGeneration);
            mapDrawer = new MapDrawer(mapGenerator.Board);
            gameBoard = mapGenerator.Board;
        }

        public Map(int mapMaxHeight, int mapMaxWidth, bool randomGeneration)
        {
            mapGenerator = new MapGenerator(mapMaxHeight, mapMaxWidth, randomGeneration);
            mapDrawer = new MapDrawer(mapGenerator.Board);
            gameBoard = mapGenerator.Board;

        }

        public Board GameBoard
        {
            get { return gameBoard; }
        }
        
    }
}
