namespace P03.Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SubmatrixRows = 3;
            const int SubmatrixColumns = 3;

            int[] dimensions = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => int.Parse(x))
                     .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row <= matrix.GetLength(0) - SubmatrixRows; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - SubmatrixColumns; col++)
                {
                    int submatrixSum = 0;

                    for (int submatrixRow = row; submatrixRow < row + SubmatrixRows; submatrixRow++)
                    {
                        for (int submatrixCol = col; submatrixCol < col + SubmatrixColumns; submatrixCol++)
                        {
                            submatrixSum += matrix[submatrixRow, submatrixCol];
                        }
                    }

                    if (maxSum < submatrixSum)
                    {
                        maxSum = submatrixSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRow; row < startRow + SubmatrixRows; row++)
            {
                for (int col = startCol; col < startCol + SubmatrixColumns; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
