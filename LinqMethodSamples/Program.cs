using System;
using System.Linq;

namespace LinqMethodSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] factoriales = { 2, 2, 3, 5, 5 };
            int factorialesUnicos = factoriales.Distinct().Count();
            Console.WriteLine($"Hay {factorialesUnicos} factoriales unicos");

            int[] numbers = { 5, 4, 1, 4, 6, 36 };
            double numSum = numbers.Sum();
            Console.WriteLine($"La suma de elementos es {numSum}");

            int minNum = numbers.Min();
            Console.WriteLine($"El numero mas chico es: {minNum}");

            int maxNum = numbers.Max();
            Console.WriteLine($"El numero mas grande es: {maxNum}");

            // Proyecciones en min y max
            string[] words = { "cherry", "apple", "banana" };
            int shortestWord = words.Min(word => word.Length);
            int longestWord = words.Max(word => word.Length);
            Console.WriteLine($"La palabra mas corta tiene: {shortestWord} caracteres");
            Console.WriteLine($"La palabra mas larga tiene: {longestWord} caracteres");

            // Promedio en un listado
            double averageNum = numbers.Average();
            Console.WriteLine($"El promedio es: {averageNum}");

            double averageLength = words.Average(word => word.Length);
            Console.WriteLine($"El promedio de caracteres es: {averageLength}");

            // Conversion de listas
            double[] doubles = { 1.4, 5.3, 5.2, 6.4 };
            var sortedDoubles = doubles.OrderBy(d => d);

            var doublesArray = sortedDoubles.ToArray();
            var doublesList = sortedDoubles.ToList();

            foreach (var d in doublesList)
                Console.WriteLine(d);

            // Conversion a diccionario
            var scores = new[]
            {
                new{ Name = "Alice", Score = 50 },
                new{ Name = "Bob", Score = 40 },
                new{ Name = "Caty", Score = 45 },
            };

            var scoresDict = scores.ToDictionary(s => s.Name, s => s);
            Console.WriteLine($"Bob's score: {scoresDict["Bob"].Score}");

            object[] numbersObjects = { null, 1.0m, "two", 3, "four", 5, "six", 7.0d};
            var doubleObjects = numbersObjects.OfType<double>();
            Console.WriteLine("Numeros guardados como dobles:");
            foreach (var obj in doubleObjects) 
            {
                Console.WriteLine(obj);
            }

            var stringObjects = numbersObjects.OfType<string>();
            Console.WriteLine("Numeros guardados como string:");
            foreach (var obj in stringObjects)
            {
                Console.WriteLine(obj);
            }

            string[] strings = { "zero", "one", "two", "three", "four", "five" };
            var firstElement = strings.First();
            var theOne = strings.First(s => s == "one");

            Console.WriteLine($"El primer elemento de la lista es {firstElement}");
            Console.WriteLine($"El primer elemento que coincide con 'one' es: {theOne}");

            string[] strings2 = { };
            var maybeTheFirstOne = strings2.FirstOrDefault();

            // Si el listado no tiene valores se le asignara el valor de 'hola'
            strings2.DefaultIfEmpty("hola").First();

            // Obtener un objeto de la posicion en un listado
            int[] numbers3 = { 5, 4, 1, 4, 6, 34};
            var elementInPosition = numbers3.ElementAt(2);
            Console.WriteLine($"Numero en la posicion 2 es: {elementInPosition}");

            // Ordenamiento de listados
            var sortedStringsAsc = strings.OrderBy(s => s);
            var sortedStringsDesc = strings.OrderByDescending(s => s);
            var sortedMultipleTimes = strings
                .OrderBy(s => s[0])
                .ThenBy(s => s.Length);

            Console.WriteLine("El orden ascendiente de la lista es:");
            foreach (var s in sortedStringsAsc)
            {
                Console.WriteLine(s);
            }


            var sortedReverse = strings.Reverse();
            Console.WriteLine("El orden al reves de la lista es:");
            foreach (var s in sortedReverse)
            {
                Console.WriteLine(s);
            }

            // Particiones en una lista
            int[] numbers4 = { 5, 4, 1, 8, 6, 4, 9, 0 };
            var first3Numbers = numbers4.Take(3);

            Console.WriteLine("Los primeros 3 numeros:");
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }

            var takeWhile = numbers4.TakeWhile(n => n > 3);
            Console.WriteLine("Tomara mientras el numero sea mayor a 3:");
            foreach (var n in takeWhile)
            {
                Console.WriteLine(n);
            }

            var allButFirst4Numbers = numbers4.Skip(4);
            Console.WriteLine("Los elementos despues de los primeros 4 son:");
            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }

            var skipWhile = numbers4.SkipWhile(num => num > 2);
            Console.WriteLine("Skip while num > 2:");
            foreach (var n in skipWhile)
            {
                Console.WriteLine(n);
            }

            // Proyecciones
            // Creamos un listado a partir de una clase anonima
            var selectList = strings.Select(c => new { Length = c.Length, Word = c });
            // Creamos un listado a partir de una clase definida
            var selectListWithEntity = strings.Select(c => new MyWord { Length = c.Length, Word = c });

            foreach (var word in selectListWithEntity)
            {
                Console.WriteLine($"La palabra {word.Word} tiene {word.Length} caracteres");
            }

            // Contains: regresa un bool si la condicion se cumple
            var siExisteZero = strings.Contains("zero");

            // Any
            var esIgualA3 = strings.Any(s => s.Equals("Three"));

            // Concat
            int[] num1 = { 1, 2, 3 };
            int[] num2 = { 4, 5, 6 };
            
        }
    }

    public class MyWord 
    {
        public int Length { get; set; }
        public string Word { get; set; }
    }
}
