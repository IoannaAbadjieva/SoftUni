namespace P02.Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SubmatrixRows = 2;
            const int SubmatrixColumns = 2;

            int[] dimensions = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => int.Parse(x))
                     .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => char.Parse(x))
                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int submatricesCount = 0;

            for (int row = 0; row <= matrix.GetLength(0) - SubmatrixRows; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - SubmatrixColumns; col++)
                {
                    char characterToCompare = matrix[row, col];
                    int counter = 0;

                    for (int submatrixRow = row; submatrixRow < row + SubmatrixRows; submatrixRow++)
                    {
                        for (int submatrixCol = col; submatrixCol < col + SubmatrixColumns; submatrixCol++)
                        {
                            if (matrix[submatrixRow, submatrixCol] == characterToCompare)
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == SubmatrixRows * SubmatrixColumns)
                    {
                        submatricesCount++;
                    }
                }

            }

            Console.WriteLine(submatricesCount);
        }
    }
}
