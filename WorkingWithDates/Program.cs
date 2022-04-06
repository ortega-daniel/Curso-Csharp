using System;

namespace WorkingWithDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;

            var x = date.ToString("ddd");
            Console.WriteLine(x);
        }
    }
}
