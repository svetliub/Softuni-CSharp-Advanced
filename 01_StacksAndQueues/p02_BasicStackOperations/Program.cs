using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int pushNum = numbers[0];
            int popNum = numbers[1];
            int numToCheck = numbers[2];

            int[] input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < pushNum; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < popNum; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numToCheck))
            {
                Console.WriteLine("true");
                return;
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Console.WriteLine(stack.Min());
        }
    }
}
