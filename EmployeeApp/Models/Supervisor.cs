using System;
using System.Text;

namespace EmployeeApp.Models
{
    public class Supervisor : Employee
    {
        public Supervisor(string name, DateTime startDate) : base(name, startDate) { }

        private void DeleteEmployee(int employeeId) 
        {
            Employee e = Database.Employees.Find(e => e.Id.Equals(employeeId));

            if (e != null)
            {
                Database.Employees.Remove(e);
                Console.WriteLine($"Successfully deleted user with ID {employeeId}");
            }
            else 
            {
                Console.WriteLine($"Employe with ID {employeeId} was not found!");
            }
        }

        /*private void ValidateEmployeeHours(int employeeId)
        {
            Employee e = Database.Employees.Find(user => user.Id.Equals(employeeId));

            if (e != null)
            {
                if (e.HoursLog.Log.Any())
                {
                    if (!e.HoursLog.Validated)
                    {
                        Console.WriteLine();
                        foreach (var log in e.HoursLog.Log)
                            Console.WriteLine($"{log.Day}: {log.Hours}hrs - {log.Description}");

                        char input = UserInput.GetCharInput("\nApprove employee's log? (y/n): ", 'y', 'n');

                        if (input.Equals('y'))
                            e.HoursLog.Validated = true;
                        else
                            e.HoursLog.Log.Clear();
                    }
                    else 
                    {
                        Console.WriteLine("Employee's log was already approved");
                    }
                }
                else 
                    Console.WriteLine("Employee's worklog is empty");
            }
            else 
                Console.WriteLine($"Employe with ID {employeeId} was not found!");
        }*/

        private void DisplayEmployeeList() 
        {
            StringBuilder result = new();
            result.AppendLine("ID\tNAME\t\tSTART DATE");

            foreach (var employee in Database.Employees)
            {
                result.AppendLine($"{employee.Id}\t{employee.Name}\t\t{employee.StartDate.ToString("d")}");
            }

            Console.WriteLine(result.ToString());
        }

        /*private Employee GetNewEmployeeData() 
        {
            string name;
            DateTime startDate;
            Console.WriteLine("New Employee");
            name = UserInput.GetStringInput("Employee name: ");
            startDate = UserInput.GetDateInput("Employee start date (dd/mm/yyyy): ");

            return new Employee(name, startDate);
        }*/
    }
}
