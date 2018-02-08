using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> result = new Stack<int>(input);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
