namespace P08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            string[] bombsCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                int row = int.Parse(bombsCoordinates[i].Split(",")[0]);
                int col = int.Parse(bombsCoordinates[i].Split(",")[1]);

                if (matrix[row, col] <= 0)
                {
                    continue;
                }
                matrix = DetonateBomb(matrix, row, col, size);
            }

            int cellsAlive = 0;
            long sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        cellsAlive++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {cellsAlive}");
            Console.WriteLine($"Sum: {sum}");
            Printmatrix(matrix);
        }

        static int[,] DetonateBomb(int[,] matrix, int row, int col, int size)
        {
            int bombpower = matrix[row, col];

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (IsCoordinatesValid(size, r, c) && matrix[r, c] > 0)
                    {
                        matrix[r, c] -= bombpower;
                    }
                }
            }

            return matrix;
        }

        static bool IsCoordinatesValid(int size, int r, int c)
        {
            return r >= 0 && r < size && c >= 0 && c < size;
        }

        static void Printmatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
