using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        private bool actionEvent;
        private bool actionPossible;
        private bool backToGame;
        private bool inGame;
        private bool inInventory;
        private bool inMenu;
        private bool inMenuCommands;
        private bool mapFound;

        public FormGame()
        {
            InitializeComponent();
            inGame = true;
            pbx_FormGameGame.Load("Pics/X.PNG");

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

                /// Up arrow
                case (char) 8:
                    if (inGame) 
                        
                        //TEMP
                        pbx_FormGameGame.Load("Pics/I.PNG");

                    ///TODO Move the player forward 
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

                /// Left arrow
                case (char) 37:
                    if (inGame)
                    {
                        /// TODO Move the player - Left
                    }

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

                /// Down arrow
                case (char) 40:
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

                /// Right arrow
                case (char) 39:
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

                /// +
                case (char) 107:
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

                /// -  
                case (char) 0:
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
                    }

                    if (inGame)
                    {
                        /// TODO Open Inventory
                    }

                    /// Flag's gestion
                    if (inInventory)
                    {
                        inInventory = false;
                        inGame = true;
                    }

                    if (inGame)
                    {
                        inInventory = true;
                        inGame = false;
                    }

                    break;

                /// C  
                case (char) 99:
                    if (inMenu) pbx_FormGameGame.Load("Pics/Menucmd.PNG");

                    /// Flag's gestion

                    if (inMenu)
                    {
                        inMenu = false;
                        inMenuCommands = true;
                    }

                    break;

                /// Q
                case (char) 113:
                    if (inMenu) Close();
                    break;

                /// Esc  
                case (char) 27:
                    if (inInventory)
                    {
                        ///TODO quit inventory an go back to game
                    }

                    if (inMenu)
                        pbx_FormGameGame.Load("Pics/X.PNG");

                    /// Quit menu and go back to game
                    if (inGame)
                        pbx_FormGameGame.Load("Pics/Menu.PNG");

                    /// Quit CMD Menu and go back to Menu
                    if (inMenuCommands)
                        pbx_FormGameGame.Load("Pics/Menu.PNG");
                    
                    /// Flag's gestion
                    if (inInventory)
                    {
                        inInventory = false;
                        inGame = true;
                    }

                    if (inMenu)
                    {
                        inMenu = false;
                        backToGame = true;
                    }

                    if (inGame)
                    {
                        inGame = false;
                        inMenu = true;
                    }

                    if (inMenuCommands)
                    {
                        inMenuCommands = false;
                        inMenu = true;
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