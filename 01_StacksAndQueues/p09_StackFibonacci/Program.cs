using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> stackFibonacci = new Stack<long>();
            stackFibonacci.Push(1);
            stackFibonacci.Push(1);

            Stack<long> temp = new Stack<long>();
            temp.Push(1);
            temp.Push(1);

            while (stackFibonacci.Count < n)
            {
                long current = temp.Pop();
                long previous = temp.Pop();

                temp.Push(current);
                temp.Push(current + previous);

                stackFibonacci.Push(current + previous);
            }

            Console.WriteLine(stackFibonacci.Pop());
        }
    }
}
