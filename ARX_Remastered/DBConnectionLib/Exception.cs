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

    [Serializable]
    public class EmailTooShortException : Exception
    {
        public EmailTooShortException()
        {

        }

        public EmailTooShortException(string message) : base(message)
        {
            message = "This Email Address is too short, please try another Email Address";
        }
    }

    [Serializable]
    public class PasswordTooShortException : Exception
    {
        public PasswordTooShortException()
        {

        }

        public PasswordTooShortException(string message):base(message)
        {
            message = "The password that you have entered is too short, please try again.";
        }
    }

    [Serializable]
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException()
        {

        }

        public EmptyFieldException(string message):base(message)
        {
            message = "Please file the field";
        }
    }
}
