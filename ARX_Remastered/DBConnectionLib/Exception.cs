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

    [Serializable]
    public class UnknownUserEmailAddressException : Exception
    {
        public UnknownUserEmailAddressException()
        {

        }

        public UnknownUserEmailAddressException(string message = "Unkown user Email Address") : base(message)
        {

        }
    }

    [Serializable]
    public class UserEmailAlreadyExistException : Exception
    {
        public UserEmailAlreadyExistException()
        {

        }

        public UserEmailAlreadyExistException(string message = "Email Address already in use") : base(message)
        {

        }
    }

    [Serializable]
    public class UsernameAlreadyExistException : Exception
    {
        public UsernameAlreadyExistException()
        {

        }

        public UsernameAlreadyExistException(string message = "Username already in use") : base(message)
        {

        }
    }
}
