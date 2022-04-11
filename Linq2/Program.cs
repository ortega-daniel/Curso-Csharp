using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2
{
    internal class Program
    {
        private static List<Student> students = new List<Student>
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

        static void Main(string[] args)
        {
            int[] scores = { 94, 76, 95, 67, 45 };

            // Usando LINQ to Objects en formato query expression
            IEnumerable<int> scoreQuery = from score in scores
                                          where score > 70
                                          select score * score;

            // Usando linq con metodos de extension y expresiones lambda
            var scoreQueryLambda = scores
                .Where(score => score > 70)
                .Select(score => score * score);

            /*foreach (var item in scoreQuery)
            {
                Console.Write($"{item} ");
            }*/

            var studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;

            var studentQueryLambda = students
                .Where(s => s.Scores[0] > 90 && s.Scores[3] < 80)
                .OrderByDescending(s => s.Scores[0]);

            var studentQueryLambdaX = students
                // All regresara solo si la condicion se cumple para todos los elementos de la lista
                .Where(student => student.Scores.All(score => score > 80))
                // Any regresara solo si la condicion se cumple en 1 de los elementos de la lista
                //.Where(student => student.Scores.All(score => score > 80))
                .OrderByDescending(student => student.Scores[0]);

            /*foreach (var student in studentQuery)
            {
                Console.WriteLine($"{student.LastName} {student.FirstName} {student.Scores[0]}");
            }*/

            var studentQuery2 =
                from student in students
                group student by student.LastName[0]
                into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            var studentQuery2Lambda = students
                .GroupBy(student => student.LastName[0])
                .OrderBy(group => group.Key);

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);

                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"nombre: {student.LastName} apellido: {student.FirstName}");
                }
            }

            // Se puede utilizar linq para realizar operaciones dentro de la comparacion y ademas regresar el valor deseado ya formateado
            var studentQuery3 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select $"{student.FirstName} {student.LastName} {totalScore / 4}";

            var studentQuery3Lambda = students
                .Where(student => (student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]) / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");

            /*foreach (var item in studentQuery3)
            {
                Console.WriteLine(item);
            }*/

            var studentQuery4 =
                from student in students
                let totalScore = student.Scores.Sum() / student.Scores.Count
                where totalScore < student.Scores[0]
                select $"{student.FirstName} {student.LastName} {totalScore}";

            var studentQuery4Lambda = students
                .Where(student => student.Scores.Sum() / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");

            var studentQuery5 =
                from student in students
                let totalScore = student.Scores.Average()
                where totalScore < student.Scores[0]
                select $"{student.FirstName} {student.LastName} {totalScore}";

            var studentQuery5Lambda = students
                .Where(student => student.Scores.Average() < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");

            // Sacar el promedio general de toda la clase
            var promedioGeneral = students.Average(s => s.Scores.Average());

            // Tambien se pueden hacer consultar linq con variable externas a ellas
            string lastName = "Garcia";
            var studentQuery6 =
                from student in students
                where student.LastName.Equals(lastName)
                select student.FirstName;

            var studentQuery6Lambda = students
                .Where(student => student.LastName.Equals(lastName))
                .Select(student => student.FirstName);

            /*Console.WriteLine($"Todos los {lastName} de la clase son:");
            Console.WriteLine(String.Join(", ", studentQuery6));*/

            // Podemos crear nuevos objetos a partir de nuestra consulta
            var studentQuery7 =
                from student in students
                let totalScore = student.Scores.Sum()
                where totalScore > promedioGeneral
                select new { ID = student.ID, Score = totalScore };

            var studentQuery7Lambda = students
                .Where(student => student.Scores.Sum() > promedioGeneral)
                .Select(student => new 
                { 
                    ID = student.ID, 
                    Score = student.Scores.Sum()
                });

            var primerEstudianteFiltrado = studentQueryLambdaX
                .Where(s => s.ID > 1000)
                .FirstOrDefault();

            var primerEstudianteFiltradoReducido = studentQueryLambdaX
                .FirstOrDefault(s => s.ID > 1000);

            Console.WriteLine(primerEstudianteFiltrado == null ? "es nulo" : primerEstudianteFiltrado.FirstName);

            var ultimoEstudianteFiltrado = studentQueryLambdaX.Last();

            Student single = studentQueryLambdaX
                .SingleOrDefault(s => s.ID == 101);

            foreach (var item in studentQuery7)
            {
                Console.WriteLine($"Student id: {item.ID} Score: {item.Score}");
            }
        }
    }

    class Student 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
}
