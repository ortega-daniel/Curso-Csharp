using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    internal class Employee : User
    {
        public List<LogItem> WorkLog { get; set; }

        public Employee(string name, DateTime startDate) : base(name, startDate) 
        { 
            WorkLog = new();
        }

        public void SetWorkLog() 
        {
            string[] days = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };
            LogItem logItem;

            for (int i = 0; i < days.Length; i++)
            {
                Console.Clear();
                logItem = new() { Day = days[i] };
                Console.WriteLine($"{days[i]} Log:");
                Console.Write("Hours: ");
                logItem.Hours = Int32.Parse(Console.ReadLine());
                Console.Write("Details: ");
                logItem.Details = Console.ReadLine();

                WorkLog.Add(logItem);
            }
        }

        public void ShowMenu() 
        {
            Console.Clear();
            Console.WriteLine("a) Set work log");
            Console.WriteLine("b) Log Out");
            Console.Write("\nYour option: ");
        }
    }
}
