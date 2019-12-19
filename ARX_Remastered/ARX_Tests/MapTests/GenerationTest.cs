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
   
            var listCase = new List<Case>()
            {
                terrainCase,
                terrainCase,
                wallCase,
                terrainCase,
                wallCase,
                terrainCase,
                terrainCase,
                wallCase,
                wallCase,
                wallCase
            };
            var board = new Board(10, 10);





            for (int i = 0; i < 10; i++)
            {
                board.BoardContent.Add(listCase);
            }

            mapdrawer.DrawMap(board);

        }
    }

}
