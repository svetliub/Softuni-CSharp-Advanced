using System;
using System.Collections.Generic;
using System.Linq;

namespace p01_DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<string> inputRow = Console.ReadLine().Split(',').ToList();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = inputRow[j];
                }
            }

            string commandArgs;

            while ((commandArgs = Console.ReadLine()) != "END")
            {
                var tokens = commandArgs.ToCharArray();
                string command = tokens[0].ToString();
                int startPositioRow = int.Parse(tokens[1].ToString());
                int startPositionColumn = int.Parse(tokens[2].ToString());
                int finalPositionRow = int.Parse(tokens[4].ToString());
                int finalPositionColumn = int.Parse(tokens[5].ToString());

                if (ProblemsCheck(matrix, startPositioRow, startPositionColumn, command, finalPositionRow, finalPositionColumn)) continue;

                if (CheckFigureMoves(command, startPositionColumn, finalPositionColumn, finalPositionRow, startPositioRow)) continue;

                matrix[finalPositionRow, finalPositionColumn] = command;
                matrix[startPositioRow, startPositionColumn] = "x";
            }
        }

        private static bool CheckFigureMoves(string command, int startPositionColumn, int finalPositionColumn,
            int finalPositionRow, int startPositioRow)
        {
            if (command == "P")
            {
                if (startPositionColumn != finalPositionColumn || finalPositionRow != startPositioRow - 1)
                {
                    Console.WriteLine("Invalid move!");
                    return true;
                }
            }

            if (command == "R")
            {
                if (startPositionColumn != finalPositionColumn && finalPositionRow != startPositioRow)
                {
                    Console.WriteLine("Invalid move!");
                    return true;
                }
            }

            if (command == "B")
            {
                if (Math.Abs(startPositionColumn - finalPositionColumn) != Math.Abs(finalPositionRow - startPositioRow))
                {
                    Console.WriteLine("Invalid move!");
                    return true;
                }
            }

            if (command == "Q")
            {
                if ((Math.Abs(startPositionColumn - finalPositionColumn) != Math.Abs(finalPositionRow - startPositioRow) &&
                     (startPositionColumn != finalPositionColumn && finalPositionRow != startPositioRow)))
                {
                    Console.WriteLine("Invalid move!");
                    return true;
                }
            }

            if (command == "K")
            {
                bool rowMove = Math.Abs(startPositioRow - finalPositionRow) == 1 &&
                               Math.Abs(startPositionColumn - finalPositionColumn) == 0;
                bool columnMove = Math.Abs(startPositionColumn - finalPositionColumn) == 1 &&
                                  Math.Abs(startPositioRow - finalPositionRow) == 0;
                bool diagonalMove = Math.Abs(startPositionColumn - finalPositionColumn) == 1 &&
                                    Math.Abs(startPositioRow - finalPositionRow) == 1;

                if (!rowMove && !columnMove && !diagonalMove)
                {
                    Console.WriteLine("Invalid move!");
                    return true;
                }
            }
            return false;
        }

        private static bool ProblemsCheck(string[,] matrix, int startPositioRow, int startPositionColumn, string command,
            int finalPositionRow, int finalPositionColumn)
        {
            if (matrix[startPositioRow, startPositionColumn] != command)
            {
                Console.WriteLine("There is no such a piece!");
                return true;
            }

            if (finalPositionRow >= 8 || finalPositionColumn >= 8)
            {
                Console.WriteLine("Move go out of board!");
                return true;
            }

            if (matrix[finalPositionRow, finalPositionColumn] != "x")
            {
                Console.WriteLine("Invalid move!");
                return true;
            }
            return false;
        }
    }
}
