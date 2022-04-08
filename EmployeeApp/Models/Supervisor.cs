using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    internal class Supervisor : User
    {
        public Supervisor(string name, DateTime startDate) : base(name, startDate, true) { }

        public void SupervisorOnly()
        {
            Console.WriteLine("Supervisor Only");
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("a) Create New Employee");
            Console.WriteLine("b) Edit Employee");
            Console.WriteLine("c) Delete Employee");
            Console.WriteLine("d) Validate Employee Hours");
            Console.WriteLine("e) Log Out");
            Console.Write("\nYour option: ");
        }

        public void ValidateEmployeeHours(int employeeId) 
        {
            Employee employee = DataBase.Users.Find(user => user.Id.Equals(employeeId)) as Employee;
            foreach (var log in employee.WorkLog)
            {
                Console.WriteLine($"{log.Day}: {log.Hours}hrs - {log.Details}");
            }
            Console.Write("\nValidate (y/n): ");
            Console.ReadLine();
        }
    }
}
