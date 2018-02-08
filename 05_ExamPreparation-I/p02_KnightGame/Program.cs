using System;

namespace p02_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[boardSize, boardSize];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            
            int row = 0;
            int column = 0;
            int countMoves = 0;

            while (true)
            {
                int maxCount = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int count = 0;

                        if (matrix[i, j] == '0')
                        {
                            continue;
                        }

                        count = Count(i, matrix, j, count);

                        if (count > maxCount)
                        {
                            maxCount = count;
                            row = i;
                            column = j;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                matrix[row, column] = '0';
                countMoves++;
            }

            Console.WriteLine(countMoves);
        }

        private static int Count(int i, char[,] matrix, int j, int count)
        {
            if ((i + 1) < matrix.GetLength(0) && (j + 2) < matrix.GetLength(1))
            {
                if (matrix[i + 1, j + 2] == 'K')
                {
                    count++;
                }
            }

            if ((i + 1) < matrix.GetLength(0) && (j - 2) >= 0)
            {
                if (matrix[i + 1, j - 2] == 'K')
                {
                    count++;
                }
            }

            if ((i - 1) >= 0 && (j - 2) >= 0)
            {
                if (matrix[i - 1, j - 2] == 'K')
                {
                    count++;
                }
            }

            if ((i - 1) >= 0 && (j + 2) < matrix.GetLength(1))
            {
                if (matrix[i - 1, j + 2] == 'K')
                {
                    count++;
                }
            }

            if ((i - 2) >= 0 && (j + 1) < matrix.GetLength(1))
            {
                if (matrix[i - 2, j + 1] == 'K')
                {
                    count++;
                }
            }

            if ((i - 2) >= 0 && (j - 1) >= 0)
            {
                if (matrix[i - 2, j - 1] == 'K')
                {
                    count++;
                }
            }

            if ((i + 2) < matrix.GetLength(0) && (j + 1) < matrix.GetLength(1) && matrix[i + 2, j + 1] == 'K')
            {
                count++;
            }

            if ((i + 2) < matrix.GetLength(0) && (j - 1) >= 0 && matrix[i + 2, j - 1] == 'K')
            {
                count++;
            }
            return count;
        }
    }
}
