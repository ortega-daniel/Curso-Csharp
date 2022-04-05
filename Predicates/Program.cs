using System;
using System.Collections.Generic;

namespace Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            Predicate<int> predicate = new Predicate<int>(GetPairs);
            Predicate<int> getPrimeNumbers = new Predicate<int>(IsPrimeNumber);

            //List<int> result = list.FindAll(predicate);
            //List<int> primeNumbers = list.FindAll(getPrimeNumbers);
            List<int> result= LambdaExpression.GetPairs();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            /*Console.WriteLine("\nPrime Numbers");
            foreach (var item in primeNumbers)
            {
                Console.WriteLine(item);
            }*/

        }

        static bool GetPairs(int num) 
        {
            if (num % 2 == 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        static bool IsPrimeNumber(int num) 
        {
            int i;
            for (i = 2; i < num; i++)
            {
                if (num % i == 0) 
                {
                    return false;
                }
            }

            if (i == num) 
            {
                return true;
            }

            return false;
        }
    }

    class LambdaExpression
    {
        private static List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static List<int> GetPairs()
        {
            return list.FindAll(x => x % 2 == 0);
        }
    }
}
