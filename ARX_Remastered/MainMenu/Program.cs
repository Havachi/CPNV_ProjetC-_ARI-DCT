/// 
/// File name : Register.cs
/// Author : Alessandro Rossi
/// Date : 21.11.2019
/// Description : This is the Enrty point of the application, 
/// this file start the form for the main menu
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenu


{
    static class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
