using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests.VisualTests
{
    public partial class ProceduralGenerationShowImage : Form
    {
        Map map;
        private MapDrawer mapDrawer;
        public ProceduralGenerationShowImage()
        {
            
            foreach (var hatchstyle in Enum.GetNames(typeof(HatchStyle)))
            {
                cmbBorderStyle.Items.Add(hatchstyle);
            }

            
            InitializeComponent();
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            map = new Map(30,30,true);

            string debugprojectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string outputFolder = $@"{debugprojectPath}\Outputs";
            pbxMapImage.ImageLocation = $@"{outputFolder}\Map600x600.bmp";


        }

        private void ProceduralGenerationShowImage_Load(object sender, EventArgs e)
        {

        }

        private void cmbBorderStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mapDrawer.BorderStyle = cmbBorderStyle.SelectedItem
        }
    }
}