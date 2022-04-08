using System;
using System.Collections.Generic;
using EmployeeApp.Models;

namespace EmployeeApp
{
    public class DataBase
    {
        public static List<User> Users { get; set; } = new List<User>() 
        {
            new Supervisor("Daniel", DateTime.Now.AddDays(-3)),
            new Employee("Juan", DateTime.Now.AddDays(-3)),
            new Employee("Pedro", DateTime.Now.AddDays(-3)),
            new Employee("Luisa", DateTime.Now.AddDays(-3)),
            new Employee("Brenda", DateTime.Now.AddDays(-3)),
            new Employee("Miguel", DateTime.Now),
        };
    }
}
