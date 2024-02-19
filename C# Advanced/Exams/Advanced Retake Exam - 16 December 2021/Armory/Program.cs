namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MinCoinsCollected = 65;

            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];

            int officerRow = 0;
            int officerCol = 0;
            int[] mirrorsCoordinates = new int[4];
            int index = 0;
            int coinsCollected = 0;

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = line[col];

                    if (line[col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    else if (line[col] == 'M')
                    {
                        mirrorsCoordinates[index++] = row;
                        mirrorsCoordinates[index++] = col;
                    }
                }
            }

            while (true)
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

                armory[officerRow, officerCol] = '-';
                if (!IsIndicesValid(armory, officerRow + rowOffset, officerCol + colOffset))
                {
                    break;
                }

                officerRow += rowOffset;
                officerCol += colOffset;

                if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    coinsCollected += armory[officerRow, officerCol] - 48;
                }
                else if (armory[officerRow, officerCol] == 'M')
                {
                    armory[officerRow, officerCol] = '-';
                    officerRow = officerRow == mirrorsCoordinates[0] ? mirrorsCoordinates[2] : mirrorsCoordinates[0];
                    officerCol = officerCol == mirrorsCoordinates[1] ? mirrorsCoordinates[3] : mirrorsCoordinates[1];
                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        coinsCollected += armory[officerRow, officerCol] - 48;
                    }
                }
                armory[officerRow, officerCol] = 'A';

                if (coinsCollected >= MinCoinsCollected)
                {
                    break;
                }
            }

            if (coinsCollected >= MinCoinsCollected)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            else
            {
                Console.WriteLine("I do not need more swords!");
            }
            Console.WriteLine($"The king paid {coinsCollected} gold coins.");
            PrintMatrix(armory);
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

