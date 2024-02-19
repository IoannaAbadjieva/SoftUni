namespace P05.Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SubmatrixRows = 2;
            const int SubmatrixCols = 2;

            string[] size = Console.ReadLine().Split(", ");
            int rows = int.Parse(size[0]);
            int columns = int.Parse(size[1]);

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string[] rowElements = Console.ReadLine().Split(", ");

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = int.Parse(rowElements[col]);

                }
            }

            int maxSum = 0;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < rows - SubmatrixRows + 1; row++)
            {
                for (int col = 0; col < columns - SubmatrixCols + 1; col++)
                {
                    int sum = 0;
                    for (int submatrixRow = row; submatrixRow < row + SubmatrixRows; submatrixRow++)
                    {
                        for (int submatrixCol = col; submatrixCol < col + SubmatrixCols; submatrixCol++)
                        {
                            sum += matrix[submatrixRow, submatrixCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            for (int row = startRow; row < startRow + SubmatrixRows; row++)
            {
                for (int col = startCol; col < startCol + SubmatrixCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);

        }
    }
}
