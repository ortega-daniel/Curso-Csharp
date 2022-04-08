using System;
using System.Collections.Generic;
using EmployeeApp.Models;

namespace EmployeeApp
{
    public class Auth
    {
        public static User ValidateCredentials(string username, string password, List<User> users) 
        {
            if (string.IsNullOrEmpty(username))
                return default;

            if (string.IsNullOrEmpty(password))
                return default;

            return users.Find(user => user.Username.Equals(username) && user.Password.Equals(password));
        }
    }
}
