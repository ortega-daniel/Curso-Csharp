using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*Console.WriteLine("Loading...");
            Asynchronous.WaitForIt();
            await Asynchronous.WaitForIt2();*/

            var elapsedTime = await Parallelism.Main();

            Console.WriteLine($"Both processes finished after {elapsedTime / 1000m} seconds");
        }
    }

    public class Asynchronous 
    {
        public static async Task WaitForIt() 
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Five seconds are up!");
        }

        public static async Task WaitForIt2() 
        {
            await Task.Delay(10000);
            Console.WriteLine("Ten seconds are up!");
        }
    }

    public class Parallelism 
    {
        public static async Task<long> Main() 
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = Process1();
            var task2 = Process2();

            await Task.WhenAll(task1, task2);
            await Task.WhenAny(task1, task2);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static async Task Process1() 
        {
            await Task.Run(() => 
            {
                Thread.Sleep(4000);
            });
        }

        public static async Task Process2() 
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }
    }
}
