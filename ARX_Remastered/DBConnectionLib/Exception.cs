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

        public UnknownUsernameException(string message = "Ce nom d'utilisateur n'existe pas") : base(message)
        {

        }
    }

    [Serializable]
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {

        }

        public InvalidPasswordException(string message = "Mot de passe incorrect") : base(message)
        {

        }
    }

    [Serializable]
    public class InvalidEmailAddressException : Exception
    {
        public InvalidEmailAddressException()
        {

        }

        public InvalidEmailAddressException(string message = "Adresse Email Invalid") : base(message)
        {

        }
    }
    [Serializable]
    public class UnknownUserEmailAddressException : Exception
    {
        public UnknownUserEmailAddressException()
        {

        }

        public UnknownUserEmailAddressException(string message = "Ce compte n'existe pas") : base(message)
        {

        }
    }

    [Serializable]
    public class UserEmailAlreadyExistException : Exception
    {
        public UserEmailAlreadyExistException()
        {

        }

        public UserEmailAlreadyExistException(string message = "Cette adresse Email est déjà utilisée") : base(message)
        {

        }
    }

    [Serializable]
    public class UsernameAlreadyExistException : Exception
    {
        public UsernameAlreadyExistException()
        {

        }

        public UsernameAlreadyExistException(string message = "Ce nom d'utilisateur est déja utilisé") : base(message)
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
            message = "L'adresse Email que vous avez utilisé n'est pas valide";
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
            message = "Le mot de passe que vous avez utilisé n'est pas valide";
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
            message = "Veuillez remplir les champs";
        }
    }
}
