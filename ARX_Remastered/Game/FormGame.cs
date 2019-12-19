using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        private bool actionEvent;
        private bool actionPossible;
        private bool backToGame;
        private bool inGame;
        private bool inFirstMenu;
        private bool backToFirstMenu = true;
        private bool inInventory;
        private bool inMenu;
        private bool disableFirstMenu;
        private bool inMenuCommands;
        private bool mapFound;

        public FormGame(string lblUsername)
        {
            InitializeComponent();
            inFirstMenu = true;
            lblUsername = @"Logged as : " + lblUsername;


            pbx_FormGameGame.Load("Pics/FirstMenu.PNG");

            //TODO Faire un bouton pour quitter le jeu sur le Mainmenu, le bouton jouer et un bouton d'aide affichant les touches de contrôle et les règles du jeu.
            //TEMP peut-être faire un background pour le main menu et pour chawue bouton avec la typo prometeus.
        }

        private void FormGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                /// W
                case (char) 119:
                    if (inGame)

                        //TEMP
                        pbx_FormGameGame.Load("Pics/X.PNG");

                    ///TODO Move the player - forward  
                    if (inInventory)
                    {
                        ///TODO  Move the inventory cursor's - up
                    }
                    break;

                /// A  
                case (char) 97:
                    if (inGame)

                        //TEMP
                        pbx_FormGameGame.Load("Pics/I.PNG");

                    /// TODO Move the player - Left
                    if (inInventory)
                    {
                        /// TODO  Move the inventory cursor's - Left
                        // TEMP IF déjà à gauche, ne bouge pas
                    }
                    break;

                /// S
                case (char) 115:
                    if (inGame)
                    {
                        /// TODO  Move the inventory cursor's - Down
                    }

                    if (inInventory)
                    {
                        /// TODO  Move the inventory cursor's - Down
                        // TEMP IF déjà en bas, ne bouge pas
                    }

                    break;

                /// D
                case (char) 100:
                    if (inGame)
                    {
                        /// TODO  Move the inventory cursor's - Right
                    }

                    if (inInventory)
                    {
                        /// TODO  Move the inventory cursor's - Right
                        // TEMP IF déjà à droite, ne bouge pas
                    }

                    break;

                /// M
                case (char) 109:
                    if (inGame)
                        if (mapFound)
                        {
                            /// TODO Zoom on the map
                        }

                    break;
                
                /// N
                case (char) 110:
                    if (inGame)
                        if (mapFound)
                        {
                            /// TODO Unzoom on the map
                        }

                    break;

                /// E
                case (char) 101:
                    if (actionEvent)
                    {
                        if (actionPossible)
                        {
                            /// TODO Check if the player as requirement (object or event) to interract
                        }

                        if (actionPossible == false)
                        {
                            /// TODO Display a message "You can't do this bla bla bla"
                        }
                    }

                    break;

                /// I
                case (char) 105:
                    if (inInventory)
                    {
                        /// TODO Quit the inventory and go back to game
                        /// 
                        inInventory = false;
                        inGame = true;
                    }

                    if (inGame)
                    {
                        /// TODO Open Inventory
                        /// 
                        inInventory = true;
                        inGame = false;
                    }
                    break;

                /// C  
                case (char) 99:
                    if (inMenu)
                    {
                        pbx_FormGameGame.Load("Pics/Menucmd.PNG");
                        inMenu = false;
                        inMenuCommands = true;
                    }

                    if (inFirstMenu)
                    {
                        pbx_FormGameGame.Load("Pics/Menucmd.PNG");
                        inFirstMenu = false;
                        backToFirstMenu = true;
                        inMenuCommands = true;
                    }

                    break;

                /// Q
                case (char) 113:
                    if (inMenu) Close();
                    if (inFirstMenu) Close();
                    break;

                /// Esc  
                case (char) 27:
                    if (inInventory)
                    {

                        ///TODO quit inventory an go back to game

                        inInventory = false;
                        inGame = true;
                    }
                    
                    if (inMenu)
                    {

                        //TODO pbx_FormGameGame.Load("Même image que en metant menu");
                        pbx_FormGameGame.Load("Pics/X.PNG");
                        inMenu = false;
                        backToGame = true;
                    }

                    if (inGame)
                    {
                        pbx_FormGameGame.Load("Pics/Menu.PNG");
                        inGame = false;
                        inMenu = true;
                    }
                    
                    if (inFirstMenu)
                    {
                        // TODO pbx_FormGameGame.Load("spawn");
                        pbx_FormGameGame.Load("Pics/X.PNG");
                        inFirstMenu = false;
                        backToFirstMenu = false;
                        inGame = true;
                    }

                    if (inMenuCommands)
                    {
                        if (backToFirstMenu)
                        {
                            pbx_FormGameGame.Load("Pics/FirstMenu.PNG");
                            inMenuCommands = false;
                            inFirstMenu = true;
                        }

                        if (backToFirstMenu == false)
                        {
                            pbx_FormGameGame.Load("Pics/Menu.PNG");
                            inMenuCommands = false;
                            inMenu = true;
                        }
                    }



                    if (backToGame)
                    {
                        inGame = true;
                        backToGame = false;
                    }
                    break;
            }
        }
    }
}