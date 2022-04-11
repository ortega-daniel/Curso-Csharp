using System;
using System.Linq;
using System.Text;

namespace EmployeeApp.Models
{
    public class Supervisor : Employee
    {
        public Supervisor(string name, DateTime startDate) : base(name, startDate) { }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome {Name}!");
            CheckAnniversaries();
            Console.WriteLine("\n1) Create New Employee");
            Console.WriteLine("2) Edit Employee");
            Console.WriteLine("3) Delete Employee");
            Console.WriteLine("4) Validate Employee Hours");
            Console.WriteLine("5) Employee List");
            Console.WriteLine("6) Log Out");
        }

        public override void ExecuteAction(int menuOption)
        {
            switch (menuOption)
            {
                case 1:
                    Console.Clear();
                    CreateEmployee();
                    break;
                case 2:
                    Console.Clear();
                    EditEmployee(UserInput.GetIntInput("Please enter the employee's ID number: "));
                    break;
                case 3:
                    Console.Clear();
                    DisplayEmployeeList();
                    DeleteEmployee(UserInput.GetIntInput("Please enter the employee's ID number: "));
                    break;
                case 4:
                    Console.Clear();
                    ValidateEmployeeHours(UserInput.GetIntInput("Please enter the employee's ID number: "));
                    break;
                case 5:
                    Console.Clear();
                    DisplayEmployeeList();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Loging out");
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void CreateEmployee() 
        {
            Employee e = GetNewEmployeeData();
            DataBase.Employees.Add(e);
            Console.WriteLine($"New employee created: {e.Name} with ID {e.Id}");
        }

        private void EditEmployee(int employeeId) 
        {
            Employee e = DataBase.Employees.Find(e => e.Id.Equals(employeeId));
            if (e != null)
            {
                Console.WriteLine($"You are now editing {e.Name} - {e.Id}");
                e.Name = UserInput.GetStringInput("New name: ");
                e.StartDate = UserInput.GetDateInput("New start date (dd/mm/yyyy): ");
                Console.WriteLine("Employee was successfully updated");
            }
            else 
            {
                Console.WriteLine($"Employe with ID {employeeId} was not found!");
            }
        }

        private void DeleteEmployee(int employeeId) 
        {
            Employee e = DataBase.Employees.Find(e => e.Id.Equals(employeeId));

            if (e != null)
            {
                DataBase.Employees.Remove(e);
                Console.WriteLine($"Successfully deleted user with ID {employeeId}");
            }
            else 
            {
                Console.WriteLine($"Employe with ID {employeeId} was not found!");
            }
        }

        private void ValidateEmployeeHours(int employeeId)
        {
            Employee e = DataBase.Employees.Find(user => user.Id.Equals(employeeId));

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
        }

        private void DisplayEmployeeList() 
        {
            StringBuilder result = new();
            result.AppendLine("ID\tNAME\t\tSTART DATE");

            foreach (var employee in DataBase.Employees)
            {
                result.AppendLine($"{employee.Id}\t{employee.Name}\t\t{employee.StartDate.ToString("d")}");
            }

            Console.WriteLine(result.ToString());
        }

        private Employee GetNewEmployeeData() 
        {
            string name;
            DateTime startDate;
            Console.WriteLine("New Employee");
            name = UserInput.GetStringInput("Employee name: ");
            startDate = UserInput.GetDateInput("Employee start date (dd/mm/yyyy): ");

            return new Employee(name, startDate);
        }
    }
}
