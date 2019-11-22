using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionLib
{
    [Serializable]
    public class UnknownUsernameException : Exception
    {
        public UnknownUsernameException()
        {

        }

        public UnknownUsernameException(string message = "Unkown Username") : base(message)
        {

        }
    }

    [Serializable]
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {

        }

        public InvalidPasswordException(string message = "Wrong Password") : base(message)
        {

        }
    }
}
