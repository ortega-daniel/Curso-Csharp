using EmployeeApp.Models;

namespace EmployeeApp.Api
{
    public class AuthApi
    {
        public static Employee ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                return default;

            if (string.IsNullOrEmpty(password))
                return default;

            return Database.GetEmployeeLogin(username, password);
        }
    }
}
