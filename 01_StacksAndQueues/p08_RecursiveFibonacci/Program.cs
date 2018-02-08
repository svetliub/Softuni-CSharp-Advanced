using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_RecursiveFibonacci
{
    class Program
    {
        public static long[] numbers;

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            numbers = new long[n + 1];
            Console.WriteLine(GetFibonacci(n));
        }

        public static long GetFibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            numbers[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);

            return numbers[n];
        }
    }
}
