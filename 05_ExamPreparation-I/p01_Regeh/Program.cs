using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace p01_Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\[\w+<(?<index>\d+)REGEH(?<index1>\d+)>\w+])";
            var regex = new Regex(pattern);

            bool containsValidExpression = regex.IsMatch(input);

            if (!containsValidExpression)
            {
                return;
            }

            MatchCollection matches = regex.Matches(input);
            List<int> indexes = new List<int>();
            int sum = 0;

            foreach (Match match in matches)
            {
                sum += int.Parse(match.Groups["index"].ToString());
                indexes.Add(sum);
                sum += int.Parse(match.Groups["index1"].ToString());
                indexes.Add(sum);
            }

            string output = String.Empty;

            for (int i = 0; i < indexes.Count; i++)
            {
                int index = indexes[i];

                if (index >= input.Length)
                {
                    index = index - input.Length + 1;
                }
                output += input[index];
            }

            Console.WriteLine(output);
        }
    }
}
