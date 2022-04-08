using System;
using System.Collections.Generic;
using EmployeeApp.Models;

namespace EmployeeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> db = DataBase.Employees;
            Employee currentUser = null;
            string username, password;
            int menuOption = 0;

            while (true)
            {
                do
                {
                    Console.Clear();
                    username = UserInput.GetStringInput("Username: ");
                    password = UserInput.GetStringInput("Password: ");

                    currentUser = Auth.ValidateCredentials(username, password, db);
                } while (currentUser == null);

                if (currentUser is Supervisor)
                {
                    Supervisor supervisor = currentUser as Supervisor;
                    do
                    {
                        supervisor.ShowMenu();
                        menuOption = UserInput.GetIntInput("\nYour option: ");
                        supervisor.Operate(menuOption);
                    } while (menuOption != 6);
                }
                else
                {
                    Employee employee = currentUser;
                    do
                    {
                        employee.ShowMenu();
                        menuOption = UserInput.GetIntInput("\nYour option: ");
                        employee.Operate(menuOption);
                    } while (menuOption != 2);
                }
            }
        }
    }
}
