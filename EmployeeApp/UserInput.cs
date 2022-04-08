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
            string result;
            while (true)
            {
                Console.Write(msg);
                result = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
        }

        public static DateTime GetDateInput(string msg) 
        {
            while (true)
            {
                Console.Write(msg);
                if (DateTime.TryParseExact(Console.ReadLine().Trim(), "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    return result;
            }
        }

        public static int GetIntInput(string msg) 
        {
            while (true)
            {
                Console.Write(msg);
                if (Int32.TryParse(Console.ReadLine().Trim(), out int result))
                    return result;
            }
        }

        public static char GetCharInput(string msg, char target1, char target2) 
        {
            char result;
            while (true)
            {
                Console.Write(msg);
                result = Console.ReadLine()[0];
                if (result.Equals(target1) || result.Equals(target2))
                    return result;
            }
        }
    }
}
