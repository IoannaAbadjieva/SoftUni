namespace P07.Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int knightsToBeremoved = 0;

            while (true)
            {
                int mostAttacks = 0;
                int rowMostAttacks = 0;
                int colMostAttacks = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int knightsAttacked = KnightsAttacked(matrix, row, col);
                            if (mostAttacks < knightsAttacked)
                            {
                                mostAttacks = knightsAttacked;
                                rowMostAttacks = row;
                                colMostAttacks = col;
                            }
                        }
                    }
                }

                if (mostAttacks == 0)
                {
                    break;
                }
                knightsToBeremoved++;
                matrix[rowMostAttacks, colMostAttacks] = '0';

            }

            Console.WriteLine(knightsToBeremoved);

        }

        static int KnightsAttacked(char[,] matrix, int row, int col)
        {
            int knightsAttacked = 0;

            if (IsIndexesValid(matrix, row + 2, col - 1))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row + 2, col + 1))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row - 2, col - 1))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row - 2, col + 1))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row + 1, col - 2))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row + 1, col + 2))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row - 1, col - 2))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    knightsAttacked++;
                }
            }
            if (IsIndexesValid(matrix, row - 1, col + 2))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    knightsAttacked++;
                }
            }
            return knightsAttacked;

        }
        static bool IsIndexesValid(char[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
        }
    }
}
