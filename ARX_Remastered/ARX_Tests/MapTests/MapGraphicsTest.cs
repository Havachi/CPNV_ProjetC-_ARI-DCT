using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib;
namespace ARX_Tests
{
    [TestClass]
    public class MapGraphicsTest
    {
        [TestMethod]
        public void TryGenerateAnMapImage()
        {
            MapGraphics map = new MapGraphics();
            map.DrawMap(new List<Wall>());
        }
    }
}
