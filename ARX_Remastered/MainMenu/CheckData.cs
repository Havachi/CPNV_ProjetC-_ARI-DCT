using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenu
{
    public class CheckData
    {
        private string username;
        private string password;

        public CheckData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void CheckLoginField(string username, string password)
        {
            if (username == "" || password == "")
            {
                throw new ArgumentNullException();
            }
        }
    }
}
