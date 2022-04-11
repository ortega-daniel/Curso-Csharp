using System;
using System.Collections.Generic;
using System.Globalization;
using EmployeeApp.Models;
using EmployeeApp.Api;

namespace EmployeeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee currentUser;
            string username, password;
            int menuOption;

            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Log in\n");
                    username = GetStringInput("Username: ");
                    password = GetStringInput("Password: ");

                    currentUser = AuthApi.ValidateCredentials(username, password);
                } while (currentUser == null);

                if (currentUser is Supervisor)
                {
                    Supervisor supervisor = currentUser as Supervisor;
                    do
                    {
                        supervisor.ShowMenu();
                        menuOption = GetIntInput("Your option: [ ]\b\b");
                        supervisor.ExecuteAction(menuOption);
                    } while (menuOption != 6);
                }
                else
                {
                    Employee employee = currentUser;
                    string employeeMenu = EmployeeApi.GetMenu();
                    do
                    {
                        Console.WriteLine(employeeMenu);
                        menuOption = GetIntInput("Your option: ");
                        switch (menuOption)
                        {
                            case 1:
                                // Set Log Entry
                                LogEntry data = new();

                                data.EmployeeId = employee.Id;
                                data.ProjectId = GetIntInput("Projects ID: ");
                                data.Date = GetDateInput("Entry date (mm/dd/yyyy): ");
                                data.Hours = GetIntInput("Hours worked: ");
                                data.Description = GetStringInput("Description: ");

                                EmployeeApi.SetLogEntry(data);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Loging out");
                                break;
                            default:
                                Console.WriteLine("Please select a valid option");
                                break;
                        }

                        Console.Write("\nPress any key to continue...");
                        Console.ReadLine();
                    } while (menuOption != 2);
                }
            }
        }

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
    }
}
