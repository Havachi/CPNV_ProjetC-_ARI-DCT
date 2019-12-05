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
        public void GenerateVoidMapTest()
        {
            Type Void = new TypeDelegator(typeof(VoidCase));
            Map map = new Map();
//            foreach (var mapCase in map.MapContent)
//            {
//                Assert.AreEqual(typeof(VoidCase) , mapCase.GetType());
//            }
        }

        [TestMethod]
        public void GenerateBorderTest()
        {
//
//            Map map = new Map();
//            map.GenerateBorderMap();
//            foreach (var mapCase in map.MapContent)
//            {
//                //todo Write all Case values in a file
//            }
        }

        [TestMethod]
        public void GenerateSeedTest()
        {
//            Map map = new Map();
//            byte[] seed1, seed2;
//
//            seed1 = map.GenerateSeed(20);
//            seed2 = map.GenerateSeed(20);
//            Assert.AreNotEqual(seed1,seed2);
            
        }
    }
}
