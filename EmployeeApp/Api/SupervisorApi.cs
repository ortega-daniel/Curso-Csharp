using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Api
{
    public class SupervisorApi
    {
        public static string GetMenu()
        {
            StringBuilder menu = new();
            menu.AppendLine("1) Create New Employee");
            menu.AppendLine("2) Edit Employee");
            menu.AppendLine("3) Delete Employee");
            menu.AppendLine("4) Validate Employee Hours");
            menu.AppendLine("5) Employee List");
            menu.AppendLine("0) Log Out");
            return menu.ToString();
        }

        public static void CreateEmployee(Employee employee) 
            => Database.Employees.Add(employee);

        public static void UpdateEmployee(int employeeId, string name, DateTime startDate) 
        {
            int index = Database.Employees.FindIndex(employee => employee.Id.Equals(employeeId));

            if (index == -1)
                throw new ApplicationException($"Employee {employeeId} dosen't exist");

            Database.Employees[index].Name = name;
            Database.Employees[index].StartDate = startDate;
        }

        public static void DeleteEmployee(int employeeId) 
        {
            Employee employee = Database.Employees.Find(employee => employee.Id.Equals(employeeId));

            if (employee is null)
                throw new ApplicationException($"Employee {employeeId} dosen't exist");

            Database.Employees.Remove(employee);
        }

        public static List<Employee> GetEmployeeList()
            => Database.Employees;
    }
}
