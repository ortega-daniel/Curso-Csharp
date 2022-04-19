using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeApp.Models;

namespace EmployeeApp.Api
{
    public class EmployeeApi
    {
        public static string GetMenu() 
        {
            StringBuilder menu = new();
            menu.AppendLine("1) Add Log Entry");
            menu.AppendLine("2) View my Work Log");
            menu.AppendLine("0) Sign Out");
            return menu.ToString();
        }

        public static void SetLogEntry(LogEntry data) 
            => Database.LogEntries.Add(data);

        public static List<LogEntry> GetLogEntries(int employeeId) 
            => Database.LogEntries.Where(entry => entry.EmployeeId == employeeId).OrderByDescending(entry => entry.Date).ToList();
    }
}
