using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    public class ArgumentNullException : Exception
    {
        public ArgumentNullException()
        {

        }

        public ArgumentNullException(string message = "One field is empty") : base(message)
        {

        }

    }

    public class UnknownUsernameException : Exception
    {
        public UnknownUsernameException()
        {

        }

        public UnknownUsernameException(string message = "Unkown Username") : base(message)
        {

        }
    }
}
