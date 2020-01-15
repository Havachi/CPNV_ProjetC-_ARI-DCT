using System;
using System.Windows.Forms;
using ARX_Tests.VisualTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class VisualTest
    {
        [TestMethod]
        public void OpenForm()
        {
            Form form = new ProceduralGenerationShowImage();
            form.ShowDialog();
        }
    }
}
