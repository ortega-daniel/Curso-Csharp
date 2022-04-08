using System;
using System.Collections.Generic;
using EmployeeApp.Models;

namespace EmployeeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> db = DataBase.Users;
            User currentUser = null;
            string user, password;

            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.Write("User: ");
                    user = Console.ReadLine().Trim();
                    Console.Write("Password: ");
                    password = Console.ReadLine().Trim();
                    currentUser = Auth.ValidateCredentials(user, password, db);

                } while (currentUser == null);

                Console.Clear();
                Console.WriteLine($"Welcome {currentUser.Name}!\n");

                char selectedOption;

                if (currentUser.IsSupervisor)
                {
                    Supervisor supervisor = currentUser as Supervisor;
                    do
                    {
                        supervisor.ShowMenu();
                        selectedOption = Console.ReadLine()[0];
                        switch (selectedOption)
                        {
                            case 'a':
                                break;
                            case 'b':
                                break;
                            case 'c':
                                break;
                            case 'd':
                                Console.Write("Employee ID: ");
                                string inputId = Console.ReadLine();
                                supervisor.ValidateEmployeeHours(Int32.Parse(inputId));
                                break;
                            case 'e':
                                break;
                            default:
                                Console.WriteLine("Please select a valid option");
                                break;
                        }
                    } while (selectedOption != 'e');
                }
                else
                {
                    Employee employee = currentUser as Employee;
                    do
                    {
                        employee.ShowMenu();
                        selectedOption = Console.ReadLine()[0];
                        switch (selectedOption)
                        {
                            case 'a':
                                employee.SetWorkLog();
                                break;
                            case 'b':
                                break;
                            default:
                                Console.WriteLine("Please select a valid option");
                                break;
                        }
                    } while (selectedOption != 'b');
                }
            }
        }
    }
}
