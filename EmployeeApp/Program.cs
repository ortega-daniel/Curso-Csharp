using System;
using System.Collections.Generic;
using System.Globalization;
using EmployeeApp.Models;
using EmployeeApp.Api;
using System.Linq;

namespace EmployeeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee currentUser;
            string username, password;
            int menuOption, employeeId;

            while (true)
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("Log in");
                    username = GetStringInput("Username: ");
                    password = GetStringInput("Password: ");

                    currentUser = AuthApi.ValidateCredentials(username, password);
                } while (currentUser == null);

                if (currentUser is Supervisor)
                {
                    Supervisor supervisor = currentUser as Supervisor;
                    string supervisorMenu = SupervisorApi.GetMenu();

                    do
                    {
                        Console.Clear();
                        Console.WriteLine(supervisorMenu);
                        menuOption = GetIntInput("Your option: ");
                        
                        switch (menuOption)
                        {
                            case 0:
                                Console.Clear();
                                Console.WriteLine("Loging out");
                                break;
                            case 1:
                                Console.Clear();
                                string name = GetStringInput("Employee name: ");
                                DateTime startDate = GetDateInput("Employee start date (dd/mm/yyyy): ");
                                Employee newEmployee = new(name, startDate);
                                SupervisorApi.CreateEmployee(newEmployee);
                                Console.WriteLine("New Employee Created");
                                break;
                            case 2:
                                Console.Clear();
                                employeeId = GetIntInput("Employee Id: ");
                                string newName = GetStringInput("New Name: ");
                                DateTime newStartDate = GetDateInput("New Start Date: ");
                                SupervisorApi.UpdateEmployee(employeeId, newName, newStartDate);
                                Console.WriteLine("Employee Updated");
                                break;
                            case 3:
                                Console.Clear();
                                int deleteId = GetIntInput("Employee Id: ");
                                SupervisorApi.DeleteEmployee(deleteId);
                                Console.WriteLine("Employee Deleted");
                                break;
                            case 4:
                                Console.Clear();
                                employeeId = GetIntInput("Employee Id: ");
                                var worklog = EmployeeApi.GetLogEntries(employeeId);
                                string input;

                                if (!worklog.Any())
                                {
                                    Console.WriteLine("Worklog is empty!");
                                }
                                else 
                                {
                                    worklog = worklog.Where(entry => !entry.IsApproved).ToList();

                                    if (!worklog.Any())
                                    {
                                        Console.WriteLine("Employee's Worklog Has Already Been Approved!");
                                    }
                                    else 
                                    {
                                        foreach (var entry in worklog)
                                        {
                                            Console.WriteLine(entry);

                                            while (true)
                                            {
                                                input = GetStringInput("Approve? (y/n): ").ToLower();
                                                if (input == "y" || input == "n")
                                                    break;
                                            }

                                            if (input == "y")
                                                entry.IsApproved = true;
                                            else
                                                entry.IsApproved = false;
                                        }
                                    }
                                }
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("== Active Employees ==\n");
                                SupervisorApi.GetEmployeeList().ForEach(employee => Console.WriteLine($" {employee.Id} - {employee.Name}"));
                                break;
                            default:
                                Console.WriteLine("Please select a valid option");
                                break;
                        }

                        Console.Write("\nPress enter to continue...");
                        _ = Console.ReadLine();
                    } while (menuOption != 0);
                }
                else
                {
                    Employee employee = currentUser;
                    string employeeMenu = EmployeeApi.GetMenu();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(employeeMenu);
                        menuOption = GetIntInput("Your option: ");

                        switch (menuOption)
                        {
                            case 0:
                                Console.Clear();
                                Console.WriteLine("Loging out");
                                break;
                            case 1:
                                Console.Clear();
                                LogEntry data = new();
                                data.EmployeeId = employee.Id;

                                var projects = ProjectApi.GetProjects();

                                Console.WriteLine("== Current Projects ==");
                                foreach (var project in projects)
                                    Console.WriteLine($" - {project.Id}: {project.Name}");

                                Console.WriteLine();
                                data.ProjectId = GetIntInput("Projects ID: ");
                                data.Date = GetDateInput("Entry date (mm/dd/yyyy): ");
                                data.Hours = GetIntInput("Hours worked: ");
                                data.Description = GetStringInput("Description: ");
                                EmployeeApi.SetLogEntry(data);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("== My Work Log ==\n");
                                EmployeeApi.GetLogEntries(employee.Id).ForEach(entry => Console.WriteLine(entry));
                                break;
                            default:
                                Console.WriteLine("Please select a valid option");
                                break;
                        }

                        Console.Write("\nPress enter to continue...");
                        _ = Console.ReadLine();
                    } while (menuOption != 0);
                }
            }
        }

        #region UserInput
        private static string GetStringInput(string msg)
        {
            string result;
            while (true)
            {
                Console.Write(msg);
                result = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
        }

        private static DateTime GetDateInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (DateTime.TryParseExact(Console.ReadLine().Trim(), "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    return result;
            }
        }

        private static int GetIntInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (Int32.TryParse(Console.ReadLine().Trim(), out int result))
                    return result;
            }
        }
        #endregion
    }
}
