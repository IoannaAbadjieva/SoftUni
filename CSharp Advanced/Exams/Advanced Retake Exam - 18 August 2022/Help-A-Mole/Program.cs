namespace Help_A_Mole
{
    internal class Program
    {
        const int PointsForWin = 25;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            int[] spesialLocationsIndexes = new int[4];
            int index = 0;

            int moleRow = -1;
            int moleCol = -1;

            int points = 0;

            for (int row = 0; row < size; row++)
            {
                string rowElements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowElements[col];

                    if (rowElements[col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                    else if (rowElements[col] == 'S')
                    {
                        spesialLocationsIndexes[index++] = row;
                        spesialLocationsIndexes[index++] = col;
                    }
                }
            }

            while (true)
            {
                int rowOffset = 0;
                int colOffset = 0;

                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (command == "up")
                {
                    rowOffset = -1;
                    colOffset = 0;
                }
                else if (command == "down")
                {
                    rowOffset = 1;
                    colOffset = 0;
                }
                else if (command == "left")
                {
                    rowOffset = 0;
                    colOffset = -1;
                }
                else if (command == "right")
                {
                    rowOffset = 0;
                    colOffset = 1;
                }

                MoveThroughField(field, spesialLocationsIndexes, ref moleRow, ref moleCol, rowOffset, colOffset, ref points);
                //PrintMatrix(field);
                //Console.WriteLine(points);

                if (points >= PointsForWin)
                {
                    break;
                }
            }

            if (points >= PointsForWin)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            PrintMatrix(field);
        }

        static void MoveThroughField(char[,] field, int[] spesialLocationsIndexes, ref int moleRow, ref int moleCol, int rowOffset, int colOffset, ref int points)
        {
            if (!IsIndexesValid(field, moleRow + rowOffset, moleCol + colOffset))
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return;
            }

            field[moleRow, moleCol] = '-';

            moleRow += rowOffset;
            moleCol += colOffset;

            char fieldCurrValue = field[moleRow, moleCol];

            if (fieldCurrValue == 'S')
            {
                field[moleRow, moleCol] = '-';
                moleRow = moleRow == spesialLocationsIndexes[0] ? spesialLocationsIndexes[2] : spesialLocationsIndexes[0];
                moleCol = moleCol == spesialLocationsIndexes[1] ? spesialLocationsIndexes[3] : spesialLocationsIndexes[1];
                points -= 3;
            }
            else if (char.IsDigit(fieldCurrValue))
            {
                points += fieldCurrValue - 48;
            }

            field[moleRow, moleCol] = 'M';
        }

        private static bool IsIndexesValid(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix)
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
