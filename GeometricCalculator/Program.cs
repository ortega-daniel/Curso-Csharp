using System;

namespace GeometricCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char selectedOption;

            do
            {
                ShowMenu();

                Console.Write("\nSelect an option: ");
                selectedOption = Char.ToLower(Console.ReadLine()[0]);

                Operate(selectedOption);

                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                Console.Clear();

            } while (selectedOption != 'e');
        }

        static void ShowMenu() 
        {
            Console.WriteLine("=== Geometric Calculator ===");
            Console.WriteLine("a) Square");
            Console.WriteLine("b) Rectangle");
            Console.WriteLine("c) Triangle (Equilateral)");
            Console.WriteLine("d) Circle");
            Console.WriteLine("e) Exit");
        }

        static void Operate(char selectedOption) 
        {
            switch (selectedOption)
            {
                case 'a':
                    Console.WriteLine("Square");
                    Console.Write("Side: ");
                    if (Double.TryParse(Console.ReadLine(), out double side))
                    {
                        DelegateCalculator.SquareOperate(side);
                        FunctionCalculator.SquareOperate(side);
                    }
                    else 
                    {
                        Console.WriteLine("Please enter a numeric value");
                    }
                    break;
                case 'b':
                    Console.WriteLine("Rectangle");
                    Console.Write("Width: ");
                    UserInput.Input1 = Console.ReadLine();
                    Console.Write("Length: ");
                    UserInput.Input2 = Console.ReadLine();

                    if (Double.TryParse(UserInput.Input1, out double width) && Double.TryParse(UserInput.Input2, out double length))
                    {
                        DelegateCalculator.RectangleOperate(width, length);
                        FunctionCalculator.RectangleOperate(width, length);
                    }
                    else 
                    {
                        Console.WriteLine("Please enter numeric values");
                    }
                    break;
                case 'c':
                    Console.WriteLine("Triangle (Equilateral)");
                    Console.Write("Side: ");
                    if (Double.TryParse(Console.ReadLine(), out double sideTri))
                    {
                        DelegateCalculator.EquilateralTriangleOperate(sideTri);
                        FunctionCalculator.EquilateralTriangleOperate(sideTri);
                    }
                    else 
                    {
                        Console.WriteLine("Please enter a numeric value");
                    }
                    break;
                case 'd':
                    Console.WriteLine("Circle");
                    Console.Write("Radius: ");
                    if (Double.TryParse(Console.ReadLine(), out double radius))
                    {
                        DelegateCalculator.CircleOperate(radius);
                        FunctionCalculator.CircleOperate(radius);
                    }
                    else 
                    {
                        Console.WriteLine("Please enter a numeric value");
                    }
                    break;
                case 'e':
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }

    class DelegateCalculator
    {
        public delegate double Square(double x);
        public delegate double Rectangle(double x, double y);
        public delegate double EquilateralTriangle(double x);
        public delegate double Circle(double x);

        public static void SquareOperate(double side)
        {
            Square area = new Square(x => x * x);
            Square perimeter = new Square(x => 4 * x);
            Console.WriteLine($"A={Math.Round(area(side), 2)}, P={Math.Round(perimeter(side), 2)}");
        }

        public static void RectangleOperate(double width, double length) 
        {
            Rectangle area = new Rectangle((x, y) => x * y);
            Rectangle perimeter = new Rectangle((x, y) => 2 * (x + y));
            Console.WriteLine($"A={Math.Round(area(width, length), 2)}, P={Math.Round(perimeter(width, length), 2)}");
        }

        public static void EquilateralTriangleOperate(double side) 
        { 
            EquilateralTriangle area = new EquilateralTriangle(x => (Math.Sqrt(3) / 4) * (x * x));
            EquilateralTriangle perimeter = new EquilateralTriangle(x => 3 * x);
            Console.WriteLine($"A={Math.Round(area(side), 2)}, P={Math.Round(perimeter(side), 2)}");
        }

        public static void CircleOperate(double radius) 
        {
            Circle area = new Circle(x => Math.PI * ( x * x));
            Circle perimeter = new Circle(x => 2 * Math.PI * x);
            Console.WriteLine($"A={Math.Round(area(radius), 2)}, P={Math.Round(perimeter(radius), 2)}");
        }
    }

    class FunctionCalculator 
    {
        public static void SquareOperate(double side) 
        {
            Func<double, double> area = x => x * x;
            Func<double, double> perimeter = x => 4 * x;
            Console.WriteLine($"A={Math.Round(area(side), 2)}, P={Math.Round(perimeter(side), 2)}");
        }

        public static void RectangleOperate(double width, double length)
        {
            Func<double, double, double> area = (x, y) => x * y;
            Func<double, double, double> perimeter = (x, y) => 2 * (x + y);
            Console.WriteLine($"A={Math.Round(area(width, length), 2)}, P={Math.Round(perimeter(width, length), 2)}");
        }

        public static void EquilateralTriangleOperate(double side)
        {
            Func<double, double> area = x => (Math.Sqrt(3) / 4) * (x * x);
            Func<double, double> perimeter = x => 3 * x;
            Console.WriteLine($"A={Math.Round(area(side), 2)}, P={Math.Round(perimeter(side), 2)}");
        }

        public static void CircleOperate(double radius)
        {
            Func<double, double> area = x => Math.PI * (x * x);
            Func<double, double> perimeter = x => 2 * Math.PI * x;
            Console.WriteLine($"A={Math.Round(area(radius), 2)}, P={Math.Round(perimeter(radius), 2)}");
        }

    }

    class UserInput 
    {
        public static string Input1 { get; set; }
        public static string Input2 { get; set; }
    }
}
