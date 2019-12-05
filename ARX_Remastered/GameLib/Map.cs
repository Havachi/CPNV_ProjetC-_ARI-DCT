using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace GameLib
{
    public class Map
    {

        Maze maze = new Maze();
        public Map()
        {
            maze.GenerateMaze();
        }
    }
}
