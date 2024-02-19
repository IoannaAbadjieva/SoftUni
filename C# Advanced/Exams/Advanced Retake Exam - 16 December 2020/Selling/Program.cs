namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MoneyNeeded = 50;

            int size = int.Parse(Console.ReadLine());
            char[,] bakery = new char[size, size];
            int[] pillarsIndices = new int[4];
            int index = 0;

            int currRow = 0;
            int currCol = 0;
            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = line[col];

                    if (line[col] == 'S')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (line[col] == 'O')
                    {
                        pillarsIndices[index++] = row;
                        pillarsIndices[index++] = col;
                    }
                }
            }
            int moneyCollected = 0;

            while (true)
            {
                int rowShift = 0;
                int colShift = 0;

                string command = Console.ReadLine();

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

                bakery[currRow, currCol] = '-';
                currRow += rowShift;
                currCol += colShift;

                if (!IsIndicesValid(bakery, currRow, currCol))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (char.IsDigit(bakery[currRow, currCol]))
                {
                    moneyCollected += bakery[currRow, currCol] - 48;
                }
                else if (bakery[currRow, currCol] == 'O')
                {
                    bakery[currRow, currCol] = '-';
                    currRow = currRow == pillarsIndices[0] ? pillarsIndices[2] : pillarsIndices[0];
                    currCol = currCol == pillarsIndices[1] ? pillarsIndices[3] : pillarsIndices[1];
                }

                bakery[currRow, currCol] = 'S';

                if (moneyCollected >= MoneyNeeded)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }
            Console.WriteLine($"Money: {moneyCollected}");
            PrintMatrix(bakery);
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
