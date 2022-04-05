using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatesWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Search: ");
            var userInput = Console.ReadLine();
            Searcher(userInput);
        }

        static void Searcher(string input) 
        {
            User.Input = input;

            List<Person> people = new()
            {
                new Person { Name = "Daniel", Age = 23, Birthday = new DateTime(1998, 6, 28) },
                new Person { Name = "Gildardo", Age = 27, Birthday = new DateTime(1995, 6, 25) },
                new Person { Name = "Rene", Age = 31, Birthday = new DateTime(1991, 2, 19) },
            };

            Predicate<Person> predicateByName = new Predicate<Person>(Person.PersonExists);
            Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);
            Predicate<Person> predicateByBirthday = new Predicate<Person>(Person.GetByBirthday);

            if (people.Exists(predicateByName))
            {
                Console.WriteLine("User exists");
            }
            else if (people.FindAll(predicateByAge).Any())
            {
                var result = people.FindAll(predicateByAge);

                Console.WriteLine("We found these users matching the given age:");
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.Write("Second date: ");
                var input2 = Console.ReadLine();
                User.Input = input2;

                var result = people.FindAll(predicateByBirthday);

                Console.WriteLine("We found these users matching the given birthday:");
                Console.WriteLine(result.Count);
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }

    class Person 
    { 
        public string Name { get; set; }
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public static bool PersonExists(Person person) 
        {
            return person.Name.Equals(User.Input);
        }

        public static bool GetByAge(Person person)
        {
            var isNumeric = Int32.TryParse(User.Input, out int age);
            if (isNumeric)
                return person.Age.Equals(age);
            else
                return false;
        }

        public static bool GetByBirthday(Person person) 
        {
            var isLowerDate = DateTime.TryParse(User.Input, out DateTime dateLower);
            var isUpperDate= DateTime.TryParse(User.Input2, out DateTime dateUpper);

            if (isLowerDate && isUpperDate)
                return (person.Birthday >= dateLower && person.Birthday <= dateUpper);
            else
                return false;
        }
    }

    class User 
    {
        public static string Input { get; set; }
        public static string Input2 { get; set; }
    }
}
