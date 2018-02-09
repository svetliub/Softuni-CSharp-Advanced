using System;
using System.Text.RegularExpressions;

namespace p04_TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)";
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int line = 0; line < numberOfLines; line++)
            {
                var inputText = Console.ReadLine();
                var regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(inputText);

                var correctMatch = matches[matches.Count / 2];

                Console.WriteLine($"Go to str. {correctMatch.Groups["streetName"]} {correctMatch.Groups["streetNumber"]}. Secret pass: {correctMatch.Groups["password"]}.");
            }
        }
    }
}
