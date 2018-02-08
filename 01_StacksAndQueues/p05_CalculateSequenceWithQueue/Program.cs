using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<long> longQueue = new Queue<long>();
            Queue<long> result = new Queue<long>();
            long num = long.Parse(Console.ReadLine());

            longQueue.Enqueue(num);
            result.Enqueue(num);

            while (result.Count <= 49)
            {
                long currentNumber = longQueue.Dequeue();

                long increment = currentNumber + 1;
                long multi = currentNumber * 2 + 1;
                long secondIncrement = currentNumber + 2;

                longQueue.Enqueue(increment);
                longQueue.Enqueue(multi);
                longQueue.Enqueue(secondIncrement);

                result.Enqueue(increment);
                if (result.Count < 50)
                {
                    result.Enqueue(multi);
                    result.Enqueue(secondIncrement);
                }

            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
