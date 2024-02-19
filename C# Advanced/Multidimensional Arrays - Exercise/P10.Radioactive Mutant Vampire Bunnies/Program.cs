namespace P10.Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];

                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();
            bool hasLost = false;

            foreach (char command in commands)
            {
                int rowShift = 0;
                int colShift = 0;

                if (command == 'U')
                {
                    rowShift--;
                }
                else if (command == 'D')
                {
                    rowShift++;
                }
                else if (command == 'L')
                {
                    colShift--;
                }
                else if (command == 'R')
                {
                    colShift++;
                }

                matrix[playerRow, playerCol] = '.';
                playerRow += rowShift;
                playerCol += colShift;

                if (!IsIndicesValid(matrix, playerRow, playerCol))
                {
                    playerRow -= rowShift;
                    playerCol -= colShift;
                    matrix = SpreadBunnies(matrix, ref hasLost);
                    break;
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    hasLost = true;
                }
                else if (matrix[playerRow, playerCol] == '.')
                {
                    matrix[playerRow, playerCol] = 'P';
                }
                matrix = SpreadBunnies(matrix, ref hasLost);

                if (hasLost)
                {
                    break;
                }
            }
            PrintMatrix(matrix);
            if (!hasLost)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }


        static bool IsIndicesValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }


        static char[,] SpreadBunnies(char[,] matrix, ref bool hasLost)
        {
            char[,] spreadMatrix = CopyMatrix(matrix);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (IsIndicesValid(matrix, row - 1, col))
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                hasLost = true;
                            }

                            spreadMatrix[row - 1, col] = 'B';
                        }

                        if (IsIndicesValid(matrix, row + 1, col))
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                hasLost = true;
                            }

                            spreadMatrix[row + 1, col] = 'B';
                        }

                        if (IsIndicesValid(matrix, row, col - 1))
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                hasLost = true;
                            }

                            spreadMatrix[row, col - 1] = 'B';
                        }

                        if (IsIndicesValid(matrix, row, col + 1))
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                hasLost = true;
                            }

                            spreadMatrix[row, col + 1] = 'B';
                        }

                    }
                }
            }

            return spreadMatrix;

        }

        private static char[,] CopyMatrix(char[,] matrix)
        {
            char[,] newMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            return newMatrix;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
