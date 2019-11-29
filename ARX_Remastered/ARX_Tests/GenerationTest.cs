using System;
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
            var m = new Maze();
            m.GenerateMaze();

        }

        [TestMethod]
        public void TestIsAlreadyVisited()
        {

            var m = new Maze();
            m.GenerateMaze();
            var caseInfoList = m.CaseInfoList;
            m.IsAlreadyVisited(caseInfoList);
        }
    }
}
