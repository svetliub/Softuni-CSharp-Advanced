using System;
using System.Linq;

namespace p02_CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int maxCount = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int k = 1; k < numbers.Count; k++)
                {
                    int count = 1;
                    int currentIndex = i;
                    int nextIndex = (i + k) % numbers.Count;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + k) % numbers.Count;
                        count++;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
            }

            Console.WriteLine(maxCount);
        }
    }
}
