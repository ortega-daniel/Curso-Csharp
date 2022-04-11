using System;
using System.Collections.Generic;
using EmployeeApp.Models;

namespace EmployeeApp
{
    public class Database
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>()
        {
            new Supervisor("Daniel", DateTime.Now.AddDays(-3)),
            new Employee("Juan", DateTime.Now.AddYears(-2)),
            new Employee("Pedro", DateTime.Now.AddDays(-3)),
            new Employee("Luisa", DateTime.Now.AddDays(-3)),
            new Employee("Brenda", DateTime.Now.AddDays(-3)),
            new Employee("Miguel", DateTime.Now.AddYears(-1)),
        };
        public static List<Project> Projects { get; set; } = new();
        public static List<LogEntry> LogEntries { get; set; } = new();

        public static Employee GetEmployeeLogin(string username, string password) 
            => Employees.Find(e => e.User.Username.Equals(username) && e.User.Password.Equals(password));

        public static void AddLogEntry(LogEntry data) 
            => LogEntries.Add(data);
    }
}
