using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class UserInput
    {
        public static string GetStringInput(string msg) 
        {
            bool isValidInput = false;
            string result = string.Empty;

            do
            {
                Console.Write(msg);
                result = Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(result)) 
                    isValidInput = true;
            } while (!isValidInput);

            return result;
        }

        public static DateTime GetDateInput(string msg) 
        {
            bool isValidInput = false;
            DateTime result;

            do
            {
                Console.Write(msg);

                if (DateTime.TryParseExact(Console.ReadLine().Trim(), "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out result)) 
                    isValidInput = true;
            } while (!isValidInput);

            return result;
        }

        public static int GetIntInput(string msg) 
        {
            bool isValidInput = false;
            int result;

            do
            {
                Console.Write(msg);

                if (Int32.TryParse(Console.ReadLine().Trim(), out result))
                    isValidInput = true;
            } while (!isValidInput);

            return result;
        }

        public static char GetCharInput(string msg, char target1, char target2) 
        {
            bool isValidInput = false;
            char result;

            do
            {
                Console.Write(msg);

                result = Console.ReadLine()[0];
                if (result.Equals(target1) || result.Equals(target2))
                    isValidInput = true;
                
            } while (!isValidInput);

            return result;
        }
    }
}
