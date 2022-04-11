﻿using System;
using System.Collections.Generic;
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
            menu.AppendLine("2) Sign Out");
            return menu.ToString();
        }

        public static List<LogEntry> GetWorkLog() 
        {
            return default;
        }

        public static void SetLogEntry(LogEntry data) => Database.AddLogEntry(data);
    }
}
