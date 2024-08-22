using System;
using System.Data;
using System.Data.SqlClient;

namespace OlineQuizApp.Models
{
    public class AdminLoginManager
    {
        private static AdminLoginManager _instance;
        private static readonly object _lock = new object();
        private string ConnectionString;
        private static bool _isAdminLoggedIn = false;

        // Private constructor to prevent instantiation from outside
        private AdminLoginManager()
        {
            ConnectionString = @"Your connection string";
        }

        // Public method to provide a global point of access to the instance
        public static AdminLoginManager GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AdminLoginManager();
                }
                return _instance;
            }
        }

        public bool ValidateAdminLogin(string email, string password)
        {
            string admin = "admin@gmail.com";
            string userEnteredEmail = email.ToLower();

            if (_isAdminLoggedIn)
            {
                //Admin already logged in. Cannot log in from another session.
                return false;
            }

            if (userEnteredEmail == admin && password == "Admin")
            {
                _isAdminLoggedIn = true;
                return true;
            }   

            return false;
        }
        public void LogoutAdmin()
        {     // Admin logged out successfully.
            _isAdminLoggedIn = false;
           
        }
    }
}
