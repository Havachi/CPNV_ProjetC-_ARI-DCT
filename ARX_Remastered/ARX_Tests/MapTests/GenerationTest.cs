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
        public void TryGenerateRandom()
        {
            var m = new Maze();
            int iteration = 0;
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\random.txt", false))
            {
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        int randomNumber = m.GenerateRandom(4);
                        iteration++;
                        file.WriteLine($"Iteration: {iteration}\nRandom number: {randomNumber}\n");
                    }
                }
            }
        }
    }
}
