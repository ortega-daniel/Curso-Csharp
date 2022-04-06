using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var quiz = InitQuiz();

            char startInput;
            do
            {
                Console.Clear();
                Console.Write("You have 15 seconds to answer 3 questions. Ready to start? (y/n): ");
                startInput = char.ToLower(Console.ReadLine()[0]);
            } while (startInput != 'y');

            StartQuizTimer();

            Console.WriteLine("\nPlease indicate your answers as a, b or c. Let's begin!\n");            

            for (int i = 0; i < quiz.Length; i++)
            {
                ShowQuestion(quiz, i);
                char answer = char.ToLower(Console.ReadLine()[0]);
                quiz[i].Answer = answer;
                Console.WriteLine();
            }
        }

        static QuizItem[] InitQuiz() 
        {
            QuizItem q1 = new QuizItem();
            QuizItem q2 = new QuizItem();
            QuizItem q3 = new QuizItem();
            q1.Question = "Cuantos metros son un kilometro?";
            q1.Options.Add('a', "1000");
            q1.Options.Add('b', "80");
            q1.Options.Add('c', "100");
            q1.CorrectAnswer = 'a';

            q2.Question = "Cual es el elemento 'Ag'?";
            q2.Options.Add('a', "Argon");
            q2.Options.Add('b', "Aluminio");
            q2.Options.Add('c', "Plata");
            q2.CorrectAnswer = 'c';

            q3.Question = "Cual es la capital de Uruguay?";
            q3.Options.Add('a', "Maldonado");
            q3.Options.Add('b', "Artigas");
            q3.Options.Add('c', "Montevideo");
            q3.CorrectAnswer = 'c';

            return new QuizItem[] { q1, q2, q3};
        }

        static void ShowQuestion(QuizItem[] quiz, int question) 
        {
            Console.WriteLine(quiz[question].Question);
            foreach (var item in quiz[question].Options) 
            {
                Console.WriteLine($"{item.Key}) {item.Value}");
            }
            Console.Write("Your answer: ");
        }

        static async Task StartQuizTimer() 
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await Task.Delay(5000);

            stopwatch.Stop();
            Console.WriteLine("Your time is over!");
        }
    }

    class QuizItem 
    {
        public string Question { get; set; }
        public Dictionary<char, string> Options{ get; set; } = new Dictionary<char, string>();
        public char CorrectAnswer { get; set; }
        public char Answer { get; set; }
    }
}
