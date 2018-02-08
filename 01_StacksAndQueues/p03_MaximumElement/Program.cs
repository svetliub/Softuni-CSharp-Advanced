using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOperations = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> max = new Stack<int>();

            for (int i = 0; i < numOperations; i++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                    if (max.Count == 0 || input[1] > max.Max())
                    {
                        max.Push(input[1]);
                    }
                }
                else if (input[0] == 2)
                {
                    int removedElement = stack.Pop();
                    if (max.Count != 0 && max.Peek() == removedElement)
                    {
                        max.Pop();
                    }
                }
                else
                {
                    Console.WriteLine(max.Max());
                }
            }
        }
    }
}
