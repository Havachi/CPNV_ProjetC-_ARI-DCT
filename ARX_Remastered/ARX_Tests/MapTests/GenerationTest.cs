using System;
using System.Collections.Generic;
using GameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class GenerationTest
    {
        [TestMethod]
        public void TryGenerateTest()
        {
            var map = new Map();
        }

        [TestMethod]
        public void TryGenerateImage()
        {
            var terrainCase = new TerrainCase();
            var wallCase = new WallCase();
            var mapdrawer = new MapDrawer();
            var board = new Board(10,10);
            var listCase = new List<Case>()
            {
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase,
                wallCase
            };
            for (int i = 0; i < 10; i++)
            {
                board.BoardContent.Add(listCase);
            }

            mapdrawer.DrawMap(board);

        }
    }

}
