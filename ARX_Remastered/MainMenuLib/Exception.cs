using System;

namespace MainMenuLib
{
    [Serializable]
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
        {

        }

        public InvalidUsernameException(string message = "Unkown Username") : base(message)
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
