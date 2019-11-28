using System;
using System.Collections.Generic;
using GameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class MapTest
    {
        
        public void GenerateVoidMap()
        {
           
            Map map = new Map();
            
            map.GenerateMap(0);
            List<Case> mapContent = map.MapContent;
            foreach (var c in mapContent)
            {
                Assert.AreEqual("void",c);
            }

        }
        [TestMethod]
        public void GenerateSeed()
        {
            Map map = new Map();
            int seed1, seed2;

            seed1 = map.GenerateSeed(20);
            seed2 = map.GenerateSeed(20);
            Assert.AreNotEqual(seed1,seed2);
            
        }
    }
}
