using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using GameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Renci.SshNet.Messages;

namespace ARX_Tests
{
    [TestClass]
    public class GenerationTest
    {
        [TestMethod]
        public void GenerateNewMapThenShowMapImage()
        {
            var map = new Map(20,20);

            //open the image
            Process photoViewer = new Process();
            photoViewer.StartInfo.FileName = @"C:\WINDOWS\system32\mspaint.exe";
            photoViewer.StartInfo.Arguments = @"C:\tmp\Maze.bmp";
            photoViewer.Start();
        }
        [TestMethod]
        public void GenerateNewMap()
        {
            var map = new Map();
        }

        [TestMethod]
        public void TryGenerateImage()
        {
            var terrainCase = new TerrainCase(0,0,0);
            var wallCase = new WallCase(0,0);
            var mapdrawer = new MapDrawer();
            var board = new Board(10, 10);
            var line = new List<Case>()
            {
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase
            };
            var boardLine = new BoardLine(line);
            for (int i = 0; i < board.Width; i++)
            {
                board.BoardContent.Add(boardLine);
                boardLine.LineContent.Reverse();
            }
            var rand = new Random();
            int r;


            mapdrawer.DrawMap(board);

        }
        [TestMethod]
        public void SpamGenerateAndShow()
        {
            
            int counter = 0;
            do
            {
                var map = new Map();
                Process photoViewer = new Process();
                photoViewer.StartInfo.FileName = @"C:\WINDOWS\system32\mspaint.exe";
                photoViewer.StartInfo.Arguments = @"C:\cmieux.bmp";
                photoViewer.Start();
                photoViewer.WaitForExit();
                counter++;
            } while (counter <= 10);
            //open the image

        }
    }

}
