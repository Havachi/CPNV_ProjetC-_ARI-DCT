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
        private MapImage mapImage;
        private Board board;

        public Map()
        {
            mapGenerator = new MapGenerator();
            mapDrawer = new MapDrawer();
            board = new Board();
            board.BoardContent = mapGenerator.ReadMap();
            mapImage = mapDrawer.DrawMap(board);
            
        }
    }
}
