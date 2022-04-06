using System;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PhoneNumberValidation();
            PasswordValidator();
        }

        static void DomainValidation() 
        {
            var domain = "https://www.something.com";
            Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$");
            Console.WriteLine(regex.IsMatch(domain));
        }

        static void PhoneNumberValidation() 
        {
            var phoneNumber = "+52 686 405 4720";
            Regex regex = new Regex(@"^\(?\+[\d]{2}\)?\s?[\d]{3}\s?[\d]{3}\s?[\d]{4}$");
            Console.WriteLine(regex.IsMatch(phoneNumber));
        }

        static void PasswordValidator() 
        {
            // contener como minimo 8 caracteres
            // al menos 1 mayuscula
            // al menos 1 minuscula
            // al menos 1 numero
            // al menos un caracter especial * # ? !
            var password = "abCD1@!!";
            Regex regex = new Regex(@"^(?=\S*[A-Z])(?=\S*[a-z])(?=\S*[0-9])(?=\S*[*#?!])\S{8,}$");
            Console.WriteLine(regex.IsMatch(password));
        }
    }
}
