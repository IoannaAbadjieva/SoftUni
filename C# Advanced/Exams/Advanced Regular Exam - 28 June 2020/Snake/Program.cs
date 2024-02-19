namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MinQtyOfEatenFood = 10;

            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size, size];
            int[] liarCoordinates = new int[4];
            int index = 0;

            int snakeRow = 0;
            int snakeCol = 0;
            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = line[col];

                    if (line[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (line[col] == 'B')
                    {
                        liarCoordinates[index++] = row;
                        liarCoordinates[index++] = col;
                    }
                }
            }


            int foodEaten = 0;

            while (true)
            {
                string command = Console.ReadLine();
                int rowShift = 0;
                int colShift = 0;

                if (command == "up")
                {
                    rowShift--;
                }
                else if (command == "down")
                {
                    rowShift++;
                }
                else if (command == "left")
                {
                    colShift--;
                }
                else if (command == "right")
                {
                    colShift++;
                }

                territory[snakeRow, snakeCol] = '.';
                snakeRow += rowShift;
                snakeCol += colShift;

                if (!IsIndicesValid(territory, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (territory[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                else if (territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';
                    snakeRow = snakeRow == liarCoordinates[0] ? liarCoordinates[2] : liarCoordinates[0];
                    snakeCol = snakeCol == liarCoordinates[1] ? liarCoordinates[3] : liarCoordinates[1];
                }

                territory[snakeRow, snakeCol] = 'S';

                if (foodEaten >= MinQtyOfEatenFood)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(territory);
        }

        static bool IsIndicesValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
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
