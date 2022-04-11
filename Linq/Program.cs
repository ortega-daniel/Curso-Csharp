using System;
using System.Linq;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Func recibe y regresa valores
            Func<int, int> square = x => x * x;
            
            // Action solo recibe valores
            Action<string> action = x => Console.WriteLine(x);

            Console.WriteLine(square(5));
            action("Hello world");

            int[] numbers = { 1, 3, 6, 8 };
            var squaredNumbers = numbers.Select(square);
            Console.WriteLine(string.Join(",", squaredNumbers));

            // Los actions pueden tambien declararse sin parametros de entrada
            Action line = () => Console.WriteLine("Hello");

            Func<int, int, string> IsTooLong = (x, y) => x > y ? "es mayor" : "es menor";

            // A partir de c# 7
            var tuplas = MisTuplas();
            Console.WriteLine($"{tuplas.Status} Mensaje: {tuplas.Message}");

            Func<int, int, (bool Stats, string Message)> myFunc = (x, y) => (x > y, "Test message");

            var aux = myFunc(1, 2);
            Console.WriteLine(aux.Message);

            // Se pueden usar delegados con parametros descartados (c# 9)
            Func<int, int, int> constant = (_, _) => 42;
            Action<int, int> constant2 = (_, _) => Console.WriteLine(42);

            // Action con serie de declaraciones
            Action<int> myActionAsync = param =>
            {
                Task.Delay(2000);
                Console.WriteLine("Me espere 2000 ms");
            };

            Console.WriteLine(IsTooLong(20, 15));
            Console.WriteLine(IsTooLong2(20, 15));

            // Action con metodo asincrono
            Action<int> myOtherActionAsync = async param => await DelayConImpresion(param);
        }

        static async Task DelayConImpresion(int x) 
        {
            await Task.Delay(2000);
            Console.WriteLine($"Me espere 2000 ms e imprimi {x}");
        }

        static (bool Status, string Message) MisTuplas() 
        {
            return (true, "mensaje de prueba");
        }

        // Metodo con cuerpo de expresion
        static string IsTooLong2(int x, int y) 
            => x > y ? "es mayor" : "es menor";
    }
}
