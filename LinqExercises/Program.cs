using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqExercises
{
    internal class Program
    {
        // Find the words in the collection that start with the letter 'L'
        static List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        // Which of the following numbers are multiples of 4 or 6
        static List<int> mixedNumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        // Output how many numbers are in this list
        static List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        static List<Customer> customers = new() 
        {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        static string[] cities = 
        { 
            "ROME", 
            "LONDON", 
            "NAIROBI", 
            "CALIFORNIA", 
            "ZURICH", 
            "NEW DELHI", 
            "AMSTERDAM", 
            "ABU DHABI", 
            "PARIS" 
        };

        static void Main(string[] args)
        {
            var result1 = fruits
                .Where(fruit => fruit[0].Equals('L'));

            var result2 = mixedNumbers
                .Where(num => num % 4 == 0 || num % 6 == 0);

            var result3 = numbers.Count;

            /*Console.WriteLine("Result 1: ");
            Console.WriteLine(string.Join(", ", result1));
            Console.WriteLine();

            Console.WriteLine("Result 2");
            Console.WriteLine(string.Join(", ", result2));
            Console.WriteLine();

            Console.WriteLine("Result 3");
            Console.WriteLine(result3);
            Console.WriteLine();*/

            // 1. Despliega cuantos millonarios hay por banco
            var millonariosPorBanco = customers
                .Where(customer => customer.Balance >= 1000000)
                .GroupBy(customer => customer.Bank); ;

            /*foreach (var bankGroup in millonariosPorBanco)
            {
                Console.WriteLine($"Millonarios del banco: {bankGroup.Key}");
                foreach (var customer in bankGroup)
                {
                    Console.WriteLine(customer.Name);
                }
            }
            Console.WriteLine();*/

            // 2. Mostrar clientes cuyo balance sea mayor a 100,000
            var r = customers
                .Where(customer => customer.Balance > 100000);

            /*Console.WriteLine("Clientes con balance mayor a $100,000");
            foreach (var customer in r)
            {
                Console.WriteLine($"{customer.Name} {customer.Balance}");
            }
            Console.WriteLine();*/

            // 3. Ordenar a los clientes por su balance
            var clientesOrdenadosPorBalance = customers
                .OrderByDescending(customer => customer.Balance);

            /*Console.WriteLine("Clientes ordenados por su balance (desc):");
            foreach (var customer in clientesOrdenadosPorBalance)
            {
                Console.WriteLine($"{customer.Name} {customer.Balance}");
            }
            Console.WriteLine();*/

            // 4. Hacer una sumatoria por riqueza por cada banco
            var riquezaPorBanco = customers
                .GroupBy(customer => customer.Bank)
                .Select(group => new 
                { 
                    Bank = group.Key, 
                    Balance = group.Sum(bank => bank.Balance) 
                });

            /*Console.WriteLine("Riqueza por banco:");
            foreach (var item in riquezaPorBanco)
            {
                Console.WriteLine($"{item.Bank}: {item.Balance}");
            }
            Console.WriteLine();*/

            // 5. Obtener el nombre de los clientes que su balance sea menor a 100,000 y su banco tenga solo 3 caracteres
            var r5 = customers
                .Where(customer => customer.Bank.Length.Equals(3))
                .Where(customer => customer.Balance < 100000);

            /*Console.WriteLine("Clientes con balance menor a $100,000 y con banco de 3 caracteres:");
            foreach (var customer in r5)
            {
                Console.WriteLine($"{customer.Name} {customer.Balance}");
            }*/

            // B.1 Find the string which starts and ends with a specific character : AM
            var citiesResult1 = cities
                .Where(city => city.Substring(0, 2).Equals("AM") && city.Substring(city.Length - 2).Equals("AM"));

            /*Console.WriteLine(String.Join(", ", citiesResult1));
            Console.WriteLine();*/

            // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            var citiesResult2 = cities
                .OrderBy(city => city.Length)
                .ThenBy(city => city);

            /*foreach (var city in citiesResult2)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();*/

            // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
            var citiesResult3 = 
                from i in Enumerable.Range(0, cities.Length) 
                group cities[i] by i / 3;

            /*foreach (var cityGroup in citiesResult3)
            {
                Console.WriteLine($"Key: {cityGroup.Key}");
                foreach (var city in cityGroup)
                {
                    Console.WriteLine(city);
                }
            }*/

            // Exercise C
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            var resultC1 = arr1
                .GroupBy(num => num)
                .Select(group => new 
                { 
                    Number = group.Key,
                    Frequency = group.Count()
                });

            /*foreach (var group in resultC1)
            {
                Console.WriteLine($"Number: {group.Number}:, Frequency: {group.Frequency}");
            }
            Console.WriteLine();*/

            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            var resultC2 = resultC1
                .Where(num => num.Frequency.Equals(1));

            /*Console.WriteLine("Unrepeated numbers:");
            foreach (var num in resultC2)
            {
                Console.WriteLine(num.Number);
            }
            Console.WriteLine();*/

            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            var resultC3 = arr1
                .GroupBy(num => num)
                .Select(group => new
                {
                    Number = group.Key,
                    MultipyByFreq = group.Key * group.Count(),
                    Frequency = group.Count()
                });

            /*foreach (var obj in resultC3)
            {
                Console.WriteLine($"Number: {obj.Number}, Freq: {obj.Frequency}, Number * Freq: {obj.MultipyByFreq}");
            }*/


            // Exercise D
            List<Student> students = new List<Student>
            {
                new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

            // D.1 Get the top student of the list making an average of their scores.
            var d1 = students
                .OrderByDescending(student => student.Scores.Average())
                .First();
            Console.WriteLine($"{d1.FirstName} {d1.LastName} is the top student with an average of {d1.Scores.Average()}");
            Console.WriteLine();

            // D.2 Get the student with the lowest average score.
            var d2 = students
                .OrderBy(student => student.Scores.Average())
                .First();
            Console.WriteLine($"{d2.FirstName} {d2.LastName} is the student with the lowest average score, with {d2.Scores.Average()}");
            Console.WriteLine();

            // D.3 Get the last name of the student that has the ID 117
            var d3 = students.Find(student => student.ID == 117).LastName;
            Console.WriteLine($"Student with an ID of 117: {d3}");
            Console.WriteLine();

            // D.4 Get the first name of the students that have any score more than 90
            var d4 = students
                .Where(student => student.Scores.Any(score => score > 90))
                .Select(student => student.FirstName);
            Console.WriteLine("Students that have any score more than 90:");
            foreach (var firstName in d4)
            {
                Console.WriteLine(firstName);
            }
        }
    }

    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
}
