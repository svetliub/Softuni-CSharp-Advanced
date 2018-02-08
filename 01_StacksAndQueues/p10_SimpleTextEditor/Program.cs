using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var old = new Stack<string>();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        old.Push(text.ToString());
                        text.Append(input[1]);
                        break;
                    case 2:
                        old.Push(text.ToString());
                        int length = int.Parse(input[1]);
                        text.Remove(text.Length - length, length);
                        break;
                    case 3:
                        Console.WriteLine(text[int.Parse(input[1]) - 1]);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(old.Pop());
                        break;
                }
            }
        }
    }
}
