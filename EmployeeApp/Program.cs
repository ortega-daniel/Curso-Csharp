﻿using System;
using System.Collections.Generic;
using EmployeeApp.Models;

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
                    username = UserInput.GetStringInput("Username: ");
                    password = UserInput.GetStringInput("Password: ");

                    currentUser = Auth.ValidateCredentials(username, password);
                } while (currentUser == null);

                if (currentUser is Supervisor)
                {
                    Supervisor supervisor = currentUser as Supervisor;
                    do
                    {
                        supervisor.ShowMenu();
                        menuOption = UserInput.GetIntInput("Your option: [ ]\b\b");
                        supervisor.ExecuteAction(menuOption);
                    } while (menuOption != 6);
                }
                else
                {
                    Employee employee = currentUser;
                    do
                    {
                        employee.ShowMenu();
                        menuOption = UserInput.GetIntInput("Your option: [ ]\b\b");
                        employee.ExecuteAction(menuOption);
                    } while (menuOption != 2);
                }
            }
        }
    }
}
