using System;

namespace LambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First operand: ");
            var input = Console.ReadLine();
            Console.Write("Second operand:");
            var input2 = Console.ReadLine();
            Console.WriteLine();

            if (Double.TryParse(input, out double x) && Double.TryParse(input2, out double y))
            {
                Console.WriteLine("Delegates:");
                DelegateCalculator.Operate(x, y);
                Console.WriteLine();
                Console.WriteLine("Func:");
                FunctionCalculator.Operate(x, y);
                Console.WriteLine();
                Console.WriteLine("Actions:");
                ActionCalculator.Operate(x, y);
            }
            else
            {
                Console.WriteLine("Please insert a numeric value");
            }
        }
    }

    class DelegateCalculator 
    {
        public delegate double SelfOperator(double x);
        public delegate double Operator(double x, double y);
        
        public static void Operate(double num1, double num2) 
        {
            /*SelfOperator square = new SelfOperator(x => x * x);
            Console.WriteLine($"Square (1st operand): {square(num)}");*/

            Operator addition = new Operator((x, y) => x + y);
            Console.WriteLine($"Addition ({num1} + {num2}): {addition(num1, num2)}");

            Operator substraction = new Operator((x, y) => x - y);
            Console.WriteLine($"Substraction ({num1} - {num2}): {substraction(num1, num2)}");

            Operator division = new Operator((x, y) => x / y);
            Console.WriteLine($"Division ({num1} / {num2}): {division(num1, num2)}");

            Operator multiplication = new Operator((x, y) => x * y);
            Console.WriteLine($"Multiplication ({num1} * {num2}): {multiplication(num1, num2)}");

            SelfOperator sin = new SelfOperator(x => Math.Sin(x));
            Console.WriteLine($"Sin (sin({num1})): {sin(num1)}");
            Console.WriteLine($"Sin (sin({num2})): {sin(num2)}");

            SelfOperator cos = new SelfOperator(x => Math.Cos(x));
            Console.WriteLine($"Cos (cos({num1})): {cos(num1)}");
            Console.WriteLine($"Cos (cos{num2}): {cos(num2)}");

            Operator power = new Operator((x, y) => Math.Pow(x, y));
            Console.WriteLine($"Power ({num1} ^ {num2}): {power(num1, num2)}");
        }
    }

    class FunctionCalculator 
    {
        public static void Operate(double num1, double num2) 
        {
            Func<double, double, double> addition = (x, y) => x + y;
            Console.WriteLine($"Addition ({num1} + {num2}): {addition(num1, num2)}");

            Func<double, double, double> substraction = (x, y) => x - y;
            Console.WriteLine($"Substraction ({num1} - {num2}): {substraction(num1, num2)}");

            Func<double, double, double> division = (x, y) => x / y;
            Console.WriteLine($"Division ({num1} / {num2}): {division(num1, num2)}");

            Func<double, double, double> multiplication = (x, y) => x * y;
            Console.WriteLine($"Multiplication ({num1} * {num2}): {multiplication(num1, num2)}");

            Func<double, double> sin = x => Math.Sin(x);
            Console.WriteLine($"Sin (sin({num1})): {sin(num1)}");
            Console.WriteLine($"Sin (sin({num2})): {sin(num2)}");

            Func<double, double> cos = x => Math.Cos(x);
            Console.WriteLine($"Cos (cos({num1})): {cos(num1)}");
            Console.WriteLine($"Cos (cos{num2}): {cos(num2)}");

            Func<double, double, double> power = (x, y) => Math.Pow(x, y);
            Console.WriteLine($"Power ({num1} ^ {num2}): {power(num1, num2)}");
        }
    }

    class ActionCalculator 
    {
        public static void Operate(double num1, double num2) 
        { 
            Action<double, double> addition= (x, y) => 
            {
                Console.WriteLine(x + y);
            };
            addition(num1, num2);
        }
    }
}
