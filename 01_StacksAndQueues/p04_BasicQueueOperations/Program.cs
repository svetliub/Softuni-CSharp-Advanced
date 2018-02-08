using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int pushNum = numbers[0];
            int popNum = numbers[1];
            int numToCheck = numbers[2];

            int[] input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < pushNum; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int i = 0; i < popNum; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numToCheck))
            {
                Console.WriteLine("true");
                return;
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Console.WriteLine(queue.Min());
        }
    }
}
