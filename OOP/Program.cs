using System;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(10);
            Triangle triangle = new Triangle(5, 5);

            Console.WriteLine($"Square area: {square.GetArea()}");
            Console.WriteLine($"Triangle area: {triangle.GetArea()}");
        }
    }

    class Polygon 
    { 
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public virtual decimal GetArea() 
        { 
            return Width * Height;
        }
    }

    class Square : Polygon
    {
        public Square(decimal side)
        {
            Width = side;
            Height = side;
        }
    }

    class Rectangle : Polygon
    {
        public Rectangle(decimal width, decimal height)
        {
            Width = width;
            Height = height;
        }
    }

    class Triangle : Polygon 
    {
        public Triangle(decimal width, decimal height) 
        { 
            Width = width;
            Height = height;
        }

        public override decimal GetArea() 
        {
            return Width * Height / 2;
        }
    }
}
