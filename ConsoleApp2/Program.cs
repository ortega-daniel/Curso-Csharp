using System;

namespace ConsoleApp2
{
    internal class Program
    {
        delegate void Del();
        delegate void Del2(string msg);

        static void Main(string[] args)
        {
            Del del = new Del(Message.Show);
            del();

            Del2 del2 = new Del2(Message2.Show);
            del2("Goodbye world");
        }
    }

    class Message 
    {
        public static void Show() 
        {
            Console.WriteLine("Hello world");
        }
    }

    class Message2 
    {
        public static void Show(string msg) 
        {
            Console.WriteLine(msg);
        }
    }
}
