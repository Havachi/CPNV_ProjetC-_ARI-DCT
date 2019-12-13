using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class FormGame : Form
    {
        private bool inGame;
        private bool backToGame;
        private bool inMenu;
        private bool inInventory;
        private bool inMenuCommands;
        private bool mapFound;
        private bool actionPossible;
        private bool actionEvent;

        public FormGame()
        {
            InitializeComponent();
            inGame = true;
            pbx_FormGameGame.Load("Pics/X.PNG");
        }
            private void FormGame_KeyPress(object sender, KeyPressEventArgs e)
            {
                switch (e.KeyChar)
                {
                    // W
                    case (char)119:
                        if (inGame == true)
                        {
                            pbx_FormGameGame.Load("Pics/X.PNG");
                            // Fait avancer le joueur
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers le haut
                        }
                        break;

                    // Up arrow
                    case (char)8:
                        if (inGame == true)
                        {
                            pbx_FormGameGame.Load("Pics/I.PNG");
                            // Fait avancer le joueur
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers le haut
                        }
                        break;

                    // A  
                    case (char)97:
                        if (inGame == true)
                        {
                             pbx_FormGameGame.Load("Pics/I.PNG");
                             // Fait tourner le joueur vers la gauche
                    }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers la gauche
                        }

                        //  Gestion de flag
                        if (inGame == true)
                        {
                        }
                        if (inInventory == true)
                        {
                        }
                        break;


                    // Left arrow
                    case (char)37:
                        if (inGame == true)
                        {
                            // Fait tourner le joueur vers la gauche
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers la gauche
                        }
                        break;

                    // S
                    case (char)115:
                        if (inGame == true)
                        {
                            // Déplace le joueur vers l'arrière
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers le bas
                        }
                        break;

                    // Down arrow
                    case (char)40:
                        if (inGame == true)
                        {
                            // Déplace le joueur vers l'arrière
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers le bas
                        }
                        break;

                    // D
                    case (char)100:
                        if (inGame == true)
                        {
                            // Fait tourner le joueur vers la droite
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers la droite
                        }
                        break;

                    // Right arrow
                    case (char)39:
                        if (inGame == true)
                        {
                            // Fait tourner le joueur vers la droite
                        }
                        if (inInventory == true)
                        {
                            // déplace la selection de l'inventaire vers la droite
                        }
                        break;

                    // M
                    case (char)109:
                        if (inGame == true)
                        {
                            if (mapFound == true) 
                            {
                                // Fait un zoom sur la map
                            }
                        }
                        break;

                    // +
                    case (char)107:
                        if (inGame == true)
                        {
                            if (mapFound == true)
                            {
                                // Fait un zoom sur la map
                            }
                        }
                        break;

                    // N
                    case (char)110:
                        if (inGame == true)
                        {
                            if (mapFound == true)
                            {
                                // Fait un dezoom sur la map
                            }
                        }
                        break;

                    // -  
                    case (char)0:
                        if (inGame == true)
                        {
                            if (mapFound == true)
                            {
                                // Fait un dezoom sur la map
                            }
                        }
                        break;

                    // E
                    case (char)101:
                        if (actionEvent == true)
                        {
                            if (actionPossible == true)
                            {
                                // Effectue une action sur l'événement si l'objet séléctionné correspond
                            }
                            if (actionPossible == false)
                            {
                                // Affcihe un message "Je ne peux pas utiliser cela bla bla bla
                            }
                        }
                        break;

                    // I
                    case (char)105: 
                        if (inInventory == true)
                        {
                            // Ferme l'inventaire et revient au jeu
                        }
                        if (inGame == true)
                        {
                            // Ouvre l'inventaire
                        }

                        //Gestion de flag
                        if (inInventory == true)
                        {
                            inInventory = false;
                            inGame = true;
                        }
                        if (inGame == true)
                        {
                            inInventory = true;
                            inGame = false;
                        }
                        break;

                    // C  
                    case (char)99:
                        if (inMenu == true)
                        {
                            pbx_FormGameGame.Load("Pics/CMD.PNG");
                        }

                        //Gestion de flag

                        if (inMenu == true)
                        {
                            inMenu = false;
                            inMenuCommands = true;
                        }
                        break;

                    // Esc  
                    case (char)27:
                        if (inInventory == true)
                        {
                            // Ferme l'inventaire et revient au jeu
                        }
                        if (inMenu == true)
                        {
                            pbx_FormGameGame.Load("Pics/X.PNG");
                        
                            // Ferme le menu et revient au jeu
                        }
                        if (inGame == true)
                        {
                            pbx_FormGameGame.Load("Pics/Menu.PNG");
                            // Ouvre le menu
                        }
                        if (inMenuCommands == true)
                        {
                            pbx_FormGameGame.Load("Pics/Menu.PNG");
                            // Ferme le menu de commande et revient au menu
                        }

                        // Gestion de flag
                        if (inInventory == true)
                        {
                            inInventory = false;
                            inGame = true;
                        }
                        if (inMenu == true)
                        {
                            inMenu = false;
                            backToGame = true;
                        }
                        if (inGame == true)
                        { 
                            inGame = false;
                            inMenu = true;
                        }
                        if (inMenuCommands == true)
                        {
                            inMenuCommands = false;
                            inMenu = true;
                        }
                        if (backToGame == true)
                        {
                            inGame = true;
                            backToGame = false;
                        }

                    break;

                    // Counts all other keys.
                    default:

                        break;
            }
        }
    }
}
