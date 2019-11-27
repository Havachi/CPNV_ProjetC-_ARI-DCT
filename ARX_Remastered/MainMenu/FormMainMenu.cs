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
    public partial class FormMainMenu : Form
    {
        private string UserEmail;

        public FormMainMenu()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
               formLogin.ShowDialog(this);
               lblMainMenuLogged.Text = $"Logged as {formLogin.Mail}";
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

    }
}
