using DBConnectionLib;

namespace MainMenuLib
{
    /// <summary>
    /// This class contain all method for login
    /// </summary>
    public class Login
    {
        private string userEmail;
        private string password;
        /// <summary>
        /// This is the constructor for the Login Object
        /// </summary>
        /// <param name="userEmail">Username of the user</param>
        /// <param name="password">Password of the user</param>
        public Login(string userEmail, string password)
        {
            this.userEmail = userEmail;
            this.password = password;

        }
        /// <summary>
        /// Check if the username and the password of the user is correct
        /// </summary>
        /// <param name="login"></param>
        /// <returns>True if OK</returns>
        /// <returns>Exception if not OK</returns>
        public bool LoginDb(Login login)
        {
            
            CheckData loginCheck = new CheckData();
            DbConnection connection = new DbConnection();
            CryptoPassword c = new CryptoPassword();

            //Check if the fields aren't empty
            loginCheck.CheckLoginField(login.userEmail, login.password);
            //Check if the userEmail exist in the database
            if (!connection.CheckEmail(userEmail))
            {
                return false;
            }
            //Get the password form the database from the validated userEmail
            var hashedPassword = connection.GetUserPassword(userEmail);
            //Return true or false if the input password match or not the database password
            return c.Verify(password, hashedPassword);
        }
    } 
}
