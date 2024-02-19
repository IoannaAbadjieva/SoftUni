namespace Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool playerWon = false;

            for (int comm = 0; comm < commandsCount; comm++)
            {
                string command = Console.ReadLine();

                int rowOffset = 0;
                int colOffset = 0;

                if (command == "up")
                {
                    rowOffset--;
                }
                else if (command == "down")
                {
                    rowOffset++;
                }
                else if (command == "left")
                {
                    colOffset--;
                }
                else if (command == "right")
                {
                    colOffset++;
                }

                matrix[playerRow, playerCol] = '-';
                playerRow += rowOffset;
                playerCol += colOffset;

                PlayerSingleMove(matrix, ref playerRow, ref playerCol, ref playerWon, command);

                matrix[playerRow, playerCol] = 'f';

                if (playerWon)
                {
                    break;
                }

            }

            if (playerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        static void PlayerSingleMove(char[,] matrix, ref int playerRow, ref int playerCol, ref bool playerWon, string command)
        {

            if (!IsIndicesValid(matrix, playerRow, playerCol))
            {
                PlayerComesIn(matrix, ref playerRow, ref playerCol);
            }

            if (matrix[playerRow, playerCol] == 'F')
            {
                matrix[playerRow, playerCol] = '-';
                playerWon = true;
                return;
            }

            if (matrix[playerRow, playerCol] == 'B')
            {
                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }
                PlayerSingleMove(matrix, ref playerRow, ref playerCol, ref playerWon, command);
            }
            else if (matrix[playerRow, playerCol] == 'T')
            {
                if (command == "up")
                {
                    playerRow++;
                }
                else if (command == "down")
                {
                    playerRow--;
                }
                else if (command == "left")
                {
                    playerCol++;
                }
                else if (command == "right")
                {
                    playerCol--;
                }
                PlayerSingleMove(matrix, ref playerRow, ref playerCol, ref playerWon, command);
            }
        }

        static bool IsIndicesValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        static void PlayerComesIn(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (playerRow > matrix.GetLength(0) - 1)
            {
                playerRow = 0;
            }
            else if (playerCol < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            else if (playerCol > matrix.GetLength(1) - 1)
            {
                playerCol = 0;
            }
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
