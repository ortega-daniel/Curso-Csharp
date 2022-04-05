using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PredicatesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char selectedOption;
            List<Employee> employees = new() 
            { 
                new Employee { Id = 101, Name = "Daniel", Area = "IT", Birthday = new DateTime(1998, 6, 28), StartDate = new DateTime(2022, 4, 1), HasParkingSpot = true },
                new Employee { Id = 102, Name = "Sergio", Area = "HR", Birthday = new DateTime(1995, 4, 16), StartDate = new DateTime(2019, 8, 6), HasParkingSpot = true },
                new Employee { Id = 103, Name = "Rodolfo", Area = "IT", Birthday = new DateTime(1990, 11, 21), StartDate = new DateTime(2022, 1, 28), HasParkingSpot = false },
                new Employee { Id = 104, Name = "Ricardo", Area = "HR", Birthday = new DateTime(2000, 10, 13), StartDate = new DateTime(2022, 2, 17), HasParkingSpot = false },
                new Employee { Id = 105, Name = "Carmen", Area = "IT", Birthday = new DateTime(2000, 4, 15), StartDate = new DateTime(2020, 3, 18), HasParkingSpot = true },
                new Employee { Id = 106, Name = "Pablo", Area = "HR", Birthday = new DateTime(2000, 5, 19), StartDate = new DateTime(2020, 9, 21), HasParkingSpot = true },
                new Employee { Id = 107, Name = "Leonardo", Area = "HR", Birthday = new DateTime(1999, 1, 17), StartDate = new DateTime(2020, 1, 27), HasParkingSpot = true },
                new Employee { Id = 108, Name = "Juan", Area = "IT", Birthday = new DateTime(2001, 9, 6), StartDate = new DateTime(2019, 4, 30), HasParkingSpot = false },
                new Employee { Id = 109, Name = "Luis", Area = "IT", Birthday = new DateTime(1997, 5, 6), StartDate = new DateTime(2019, 7, 10), HasParkingSpot = true },
                new Employee { Id = 110, Name = "Miguel", Area = "IT", Birthday = new DateTime(1998, 8, 3), StartDate = new DateTime(2021, 1, 5), HasParkingSpot = true },
            };
            
            do
            {
                DisplayMenu();

                Console.Write("\nSelect an option: ");
                selectedOption = Char.ToLower(Console.ReadLine()[0]);
                
                Search(selectedOption, employees);
                
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                Console.Clear();

            } while (selectedOption != 'g');
        }

        static void DisplayMenu() 
        {
            Console.WriteLine("==== Employee Menu ==== ");
            Console.WriteLine("a) Find by Employee Number");
            Console.WriteLine("b) Find by Name");
            Console.WriteLine("c) Find by Area");
            Console.WriteLine("d) Find by Birthday");
            Console.WriteLine("e) Find by Start Date");
            Console.WriteLine("f) Find by Parking Spot");
            Console.WriteLine("g) Exit");
        }

        static void Search(char selectedOption, List<Employee> employeeDb) 
        {
            List<Employee> result;

            switch (selectedOption)
            {
                case 'a':
                    Console.WriteLine("Filter by Employee Number");
                    Console.Write("Number: ");
                    UserInput.Input1 = Console.ReadLine();

                    Predicate<Employee> predicateById = new Predicate<Employee>(Employee.GetById);
                    result = employeeDb.FindAll(predicateById);

                    if (result.Any())
                    {
                        Console.WriteLine("Results:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Area} - {item.Birthday} - {item.StartDate}");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("0 records found");
                    }
                    break;
                case 'b':
                    Console.WriteLine("Filter by Employee Name");
                    Console.Write("Name: ");
                    UserInput.Input1 = Console.ReadLine();

                    Predicate<Employee> predicateByName = new Predicate<Employee>(Employee.GetByName);
                    result = employeeDb.FindAll(predicateByName);
                    if (result.Any())
                    {
                        Console.WriteLine("Results:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Area} - {item.Birthday} - {item.StartDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("0 records found");
                    }
                    break;
                case 'c':
                    Console.WriteLine("Filter by Area");
                    Console.Write("Area: ");
                    UserInput.Input1 = Console.ReadLine();

                    Predicate<Employee> predicateByArea = new Predicate<Employee>(Employee.GetByArea);
                    result = employeeDb.FindAll(predicateByArea);
                    if (result.Any())
                    {
                        Console.WriteLine("Results:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Area} - {item.Birthday} - {item.StartDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("0 records found");
                    }
                    break;
                case 'd':
                    Console.WriteLine("Filter by Birthday Range");
                    Console.Write("From (date): ");
                    UserInput.Input1 = Console.ReadLine();
                    Console.Write("To (date): ");
                    UserInput.Input2 = Console.ReadLine();

                    Predicate<Employee> predicateByBirthday = new Predicate<Employee>(Employee.GetByBirthday);
                    result = employeeDb.FindAll(predicateByBirthday);
                    if (result.Any()) 
                    {
                        Console.WriteLine("Results:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Area} - {item.Birthday} - {item.StartDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("0 records found");
                    }
                    break;
                case 'e':
                    Console.WriteLine("Filter by Start Date");
                    Console.Write("From (date): ");
                    UserInput.Input1 = Console.ReadLine();
                    Console.Write("To (date): ");
                    UserInput.Input2 = Console.ReadLine();

                    Predicate<Employee> predicateByStartDate = new Predicate<Employee>(Employee.GetByStartDate);
                    result = employeeDb.FindAll(predicateByStartDate);
                    if (result.Any())
                    {
                        Console.WriteLine("Results:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Area} - {item.Birthday} - {item.StartDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("0 records found");
                    }
                    break;
                case 'f':
                    Console.WriteLine("Filter by Parking Spot");
                    Console.Write("true/false: ");
                    UserInput.Input1 = Console.ReadLine();

                    Predicate<Employee> predicateByParkingSpot = new Predicate<Employee>(Employee.GetByParkingSpot);
                    result = employeeDb.FindAll(predicateByParkingSpot);
                    if (result.Any())
                    {
                        Console.WriteLine("Results:");
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.Area} - {item.Birthday} - {item.StartDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("0 records found");
                    }
                    break;
                case 'g':
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }

    class Employee 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; }
        public bool HasParkingSpot { get; set; }

        public static bool GetById(Employee employee) 
        {
            bool isNumeric = Int32.TryParse(UserInput.Input1, out int id);
            
            if (isNumeric)
            {
                return employee.Id.Equals(id);
            }
            else 
            {
                return false;
            }
        }

        public static bool GetByName(Employee employee) 
        {
            return employee.Name.Equals(UserInput.Input1);
        }

        public static bool GetByArea(Employee employee)
        {
            return employee.Area.Equals(UserInput.Input1);
        }

        public static bool GetByBirthday(Employee employee) 
        {
            try 
            {
                DateTime fromDate = DateTime.ParseExact(UserInput.Input1, "d", CultureInfo.InvariantCulture);
                DateTime toDate= DateTime.ParseExact(UserInput.Input2, "d", CultureInfo.InvariantCulture);

                return employee.Birthday >= fromDate && employee.Birthday <= toDate;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool GetByStartDate(Employee employee)
        {
            try
            {
                DateTime fromDate = DateTime.ParseExact(UserInput.Input1, "d", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(UserInput.Input2, "d", CultureInfo.InvariantCulture);

                return employee.StartDate > fromDate && employee.StartDate < toDate;
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect date format, should be MM/DD/YYYY");
                return false;
            }
        }

        public static bool GetByParkingSpot(Employee employee) 
        {
            var isBoolean = Boolean.TryParse(UserInput.Input1, out bool flag);

            if (isBoolean)
            {
                if (flag)
                {
                    return employee.HasParkingSpot == true;
                }
                else if (!flag)
                {
                    return employee.HasParkingSpot == false;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }
    }

    class UserInput 
    {
        public static string Input1 { get; set; }
        public static string Input2 { get; set; }
    }
}
