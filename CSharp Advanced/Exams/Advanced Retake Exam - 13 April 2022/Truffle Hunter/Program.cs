namespace Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] forest = new string[size, size];
            Dictionary<string, int> truffles = new Dictionary<string, int>()
            {
                { "B",0},
                { "S",0},
                { "W",0},
            };

            for (int row = 0; row < size; row++)
            {
                string[] rowItems = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = rowItems[col];
                }
            }

            int wildBoarTruffles = 0;
            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (cmdType == "Collect")
                {
                    string currPosition = forest[row, col];

                    if (currPosition == "B" || currPosition == "S" || currPosition == "W")
                    {
                        truffles[currPosition]++;
                        forest[row, col] = "-";
                    }
                }
                else if (cmdType == "Wild_Boar")
                {
                    string direction = cmdArgs[3];
                    wildBoarTruffles += EatTruffles(forest, truffles, row, col, direction);
                }
            }
            Console.WriteLine($"Peter manages to harvest {truffles["B"]} black, {truffles["S"]} summer, and {truffles["W"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffles} truffles.");
            PrintMatrix(forest);
        }

        private static void PrintMatrix(string[,] matrix)
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

        static int EatTruffles(string[,] forest, Dictionary<string, int> truffles, int row, int col, string direction)
        {
            int eatenTruffles = 0;

            if (direction == "up")
            {
                for (int r = row; r >= 0; r -= 2)
                {
                    if (truffles.ContainsKey(forest[r, col]))
                    {
                        eatenTruffles++;
                        forest[r, col] = "-";
                    }
                }
            }
            else if (direction == "down")
            {
                for (int r = row; r < forest.GetLength(0); r += 2)
                {
                    if (truffles.ContainsKey(forest[r, col]))
                    {
                        eatenTruffles++;
                        forest[r, col] = "-";
                    }
                }
            }
            else if (direction == "left")
            {
                for (int c = col; c >= 0; c -= 2)
                {
                    if (truffles.ContainsKey(forest[row, c]))
                    {
                        eatenTruffles++;
                        forest[row, c] = "-";
                    }
                }
            }
            else if (direction == "right")
            {
                for (int c = col; c < forest.GetLength(1); c += 2)
                {
                    if (truffles.ContainsKey(forest[row, c]))
                    {
                        eatenTruffles++;
                        forest[row, c] = "-";
                    }
                }
            }

            return eatenTruffles;
        }
    }
}
