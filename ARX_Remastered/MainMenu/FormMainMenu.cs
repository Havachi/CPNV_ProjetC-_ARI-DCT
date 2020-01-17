using System;
using System.Windows.Forms;
using Game;
using MainMenu.Properties;

// Resharper disable all

namespace MainMenu
{
    /// <summary>
    ///     This is the form for the main menu
    /// </summary>
    public partial class FormMainMenu : Form
    {
        private string userEmail;
        private bool isLogged;
        public FormMainMenu()
        {
            InitializeComponent();
            this.Tag = isLogged;
        }

        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        /// <summary>
        ///     If the user Click on the login button, the login form appears
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
                formLogin.ShowDialog(this);
                string lblUsername = formLogin.UserEmail;

                /// TODO Call game generator
                /// TODO Generate player's attributes (Pos, inventory and so on)
                /// TODO Call event and item generator

                FormGame frmGame = new FormGame(lblUsername);
                frmGame.ShowDialog();
            }
        }

            private void MainMenu_Load(object sender, EventArgs e)
        {
            if (Settings.Default.FormMainSize.Width == 0) Settings.Default.Upgrade();

            if (Settings.Default.FormMainSize.Width == 0 || Settings.Default.FormMainSize.Height == 0)
            {
            }
            else
            {
                this.WindowState = Settings.Default.FormMainState;
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Settings.Default.FormMainLoc;
                this.Size = Settings.Default.FormMainSize;
            }
        }

        private void MainMenu_Closing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.FormMainState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // Save location and size if the state is normal
                Settings.Default.FormMainLoc = this.Location;
                Settings.Default.FormMainSize = this.Size;
            }
            else
            {
                Settings.Default.FormMainLoc = this.RestoreBounds.Location;
                Settings.Default.FormMainSize = this.RestoreBounds.Size;
            }

            // Save the settings
            Settings.Default.Save();
        }
        public bool IsLogged
        {
            get { return isLogged; }
            set { isLogged = value; }
        }
        
    }
}