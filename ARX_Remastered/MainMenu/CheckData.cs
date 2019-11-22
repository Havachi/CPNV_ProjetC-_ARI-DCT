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
        private List<string> illegalChar = new List<string>();

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

        private void populateIllegalChar()
        {
            illegalChar.Add("-- ");
            illegalChar.Add("/*");
            illegalChar.Add("*/");
        }
        public void VerifRegister(string username, string password)
        {

            if (username.Length < 8)
            {
                Exception e = new Exception("Username too short");
                throw e;
            }
            else
            {
                populateIllegalChar();
                foreach (var c in illegalChar)
                {
                    foreach (var i in illegalChar)
                    {
                        if (c.Contains(i))
                        {
                            Exception e = new Exception("Invalid username");
                            throw e;
                        }
                    }
                }
            }
            if (password.Length < 8)
            {
                Exception e = new Exception("Password too short");
                throw e;
            }
            else
            {
                //Password encryption
            }

        }
    }
}
