using System;

namespace MainMenuLib
{
    [Serializable]
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
        {

        }

<<<<<<< Updated upstream
        public ArgumentNullException(string message = "One field is empty") : base(message)
        {

        }
=======
        public InvalidUsernameException(string message = "Unkown Username") : base(message)
        {
>>>>>>> Stashed changes

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
