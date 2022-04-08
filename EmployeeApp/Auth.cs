using System;
using System.Collections.Generic;
using EmployeeApp.Models;

namespace EmployeeApp
{
    public class Auth
    {
        public static Employee ValidateCredentials(string username, string password) 
        {
            if (string.IsNullOrEmpty(username))
                return default;

            if (string.IsNullOrEmpty(password))
                return default;

            return DataBase.Employees.Find(e => e.User.Username.Equals(username) && e.User.Password.Equals(password));
        }
    }
}
