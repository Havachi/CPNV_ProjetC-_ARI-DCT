using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenu
{
    public partial class FormSignupSucess : Form
    {
        public FormSignupSucess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            {
                Close();
            }
        }
    }
}