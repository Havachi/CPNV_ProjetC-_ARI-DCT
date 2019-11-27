using System;
using System.Collections.Generic;
using MapLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void GenerateVoidMap()
        {
           
            Map map = new Map();
            
            map.generateMap(0);
            List<Case> mapContent = map.MapContent;
            foreach (var c in mapContent)
            {
                Assert.AreEqual("void",c.CaseType);
            }

        }

        public void GenerateLevel1()
        {
            Map map = new Map();

            map.generateMap(0);
            List<Case> mapContent = map.MapContent;
            foreach (var c in mapContent)
            {
                Assert.AreEqual("void", c.CaseType);
            }
        }
    }
}
