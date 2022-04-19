using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public User User { get; set; }
        public List<LogEntry> WorkLog { get; set; } = new();

        private static int _employeeSeed = 1000;

        public Employee(string name, DateTime startDate)
        {
            Id = _employeeSeed++;
            Name = name;
            StartDate = startDate;
            User = new User { Username = Id.ToString(), Password = Id.ToString() };
        }

        /*public void SetWorkLog() 
        {
            if (HoursLog.Log.Any())
            {
                Console.Clear();
                Console.WriteLine("You already entered your hour log");
            }
            else 
            {
                string[] days = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };
                LogItem logItem;

                for (int i = 0; i < days.Length; i++)
                {
                    Console.Clear();
                    logItem = new() { Day = days[i] };
                    Console.WriteLine($"{days[i]} Log:");

                    logItem.Hours = UserInput.GetIntInput("Hours: ");
                    logItem.Description = UserInput.GetStringInput("Details: ");

                    HoursLog.Log.Add(logItem);
                }
            }
        }*/

        /*protected void CheckAnniversaries() 
        {
            var result = DataBase.Employees.FindAll(e => e.StartDate.Month.Equals(DateTime.Now.Month) && e.StartDate.Day.Equals(DateTime.Now.Day) && e.StartDate.Year < DateTime.Now.Year);
            
            if (result.Any())
                Console.WriteLine("Work Anniversaries");

            foreach (var item in result)
            {
                Console.WriteLine($"- {item.Name} {DateTime.Now.Year - item.StartDate.Year} years");
            }
        }*/
    }
}
