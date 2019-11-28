using System;
using System.Collections.Generic;
using System.Reflection;
using GameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void GenerateVoidMap()
        {
            Type Void = new TypeDelegator(typeof(VoidCase));
            Map map = new Map();
            byte[] levelSeedBytes = new byte[20];
            levelSeedBytes = map.GenerateSeed(20);
            map.LoadMap(levelSeedBytes);
            List<Case> mapContent = map.MapContent;

            foreach (var c in mapContent)
            {
                Assert.IsInstanceOfType(c, Void);
            }
            

        }
        [TestMethod]
        public void GenerateSeedTest()
        {
            Map map = new Map();
            byte[] seed1, seed2;

            seed1 = map.GenerateSeed(20);
            seed2 = map.GenerateSeed(20);
            Assert.AreNotEqual(seed1,seed2);
            
        }
    }
}
