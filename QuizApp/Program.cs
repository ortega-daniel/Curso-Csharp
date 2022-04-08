using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("You have 15 seconds to answer 3 questions. Ready to start? (y/n)");
            var input = Console.ReadLine();

            if (!input.ToLower().Equals("y"))
                return;

            Console.WriteLine("");
            var result = await Exam.Start();
            Console.WriteLine("");

            if (result.IsTimeOut)
                Console.WriteLine("Sorry, your time is up.");
            else
                Console.WriteLine($"Congratulations! You finished at {result.TimeSpan / 1000m} seconds.\nYour grade is {Math.Round(result.Grade / 3m, 2)}");
        }
    }

    public class Result
    {
        public int Grade { get; set; } = 0;
        public long TimeSpan { get; set; }
        public bool IsTimeOut { get; set; }
    }

    public class Question
    {
        public string Questionate { get; set; }
        public List<string> Options { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }
    }

    public class Exam
    {
        public static List<Question> Create()
        {
            return new List<Question>()
        {
            new Question() {
                Questionate = "¿Cuántos metros son un kilómetro?",
                Options = new List<string>() { "100", "80", "50" },
                Answer = "a",
            },
            new Question()
            {
                Questionate = "¿Cuál es el elemento 'Ag'?",
                Options = new List<string>() { "Argón", "Aluminio", "Plata" },
                Answer = "c"
            },
            new Question()
            {
                Questionate = "¿Cuál es la capital de Uruguay?",
                Options = new List<string>() { "Maldonado", "Artigas", "Montevideo" },
                Answer = "c"
            }
        };
        }

        public static async Task<Result> Start()
        {
            Console.WriteLine("Please indicate your answers as a, b or c. Let's begin!");
            var questions = Create();
            var result = new Result();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var timeout = Process1();

            foreach (var question in questions)
            {
                if (timeout.IsCompleted)
                    break;

                Console.WriteLine("");
                Console.WriteLine($"{question.Questionate}\na) {question.Options[0]}\nb) {question.Options[1]}\nc) {question.Options[2]}");
                Console.Write("Your answer: ");
                var answer = Console.ReadLine();

                if (answer.Equals(question.Answer))
                    result.Grade += 100;
            }

            stopwatch.Stop();

            if (timeout.IsCompleted)
            {
                result.TimeSpan = 15000;
                result.IsTimeOut = true;
            }
            else
            {
                result.TimeSpan = stopwatch.ElapsedMilliseconds;
                result.IsTimeOut = false;
            }

            return result;
        }

        public static async Task Process1()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(15000);
            });
        }
    }
}
