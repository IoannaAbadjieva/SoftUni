namespace Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int startRow = 0;
            int startCol = 0;
            int totalBranchesCount = 0;

            List<char> branches = new List<char>();
            char[,] pond = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = line[col];

                    if (line[col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (char.IsLower(line[col]))
                    {
                        totalBranchesCount++;
                    }
                }
            }
            //Console.WriteLine($"Starting position: {startRow}  {startCol}");
            //Console.WriteLine($"branchesCount: {branchesCount}");
            //PrintMatrix(pond);

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
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

                if (!IsIndicesValid(pond, startRow + rowOffset, startCol + colOffset))
                {
                    if (branches.Count > 0)
                    {
                        branches.RemoveAt(branches.Count - 1);
                    }
                    continue;
                }

                pond[startRow, startCol] = '-';
                startRow += rowOffset;
                startCol += colOffset;

                if (char.IsLower(pond[startRow, startCol]))
                {
                    branches.Add(pond[startRow, startCol]);
                    totalBranchesCount--;
                }
                else if (pond[startRow, startCol] == 'F')
                {
                    EatFish(pond, branches, command, ref startRow, ref startCol, ref totalBranchesCount);
                }
                pond[startRow, startCol] = 'B';

                if (totalBranchesCount == 0)
                {
                    break;
                }

                //Console.WriteLine($"branchesCount: {branches.Count}");
                //PrintMatrix(pond);
            }

            if (totalBranchesCount == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranchesCount} branches left.");
            }
            PrintMatrix(pond);
        }

        private static void EatFish(char[,] pond, List<char> branches, string command, ref int startRow, ref int startCol, ref int totalBranchesCount)
        {
            pond[startRow, startCol] = '-';

            if (command == "up")
            {
                startRow = startRow > 0 ? 0 : pond.GetLength(0) - 1;

            }
            else if (command == "down")
            {
                startRow = startRow < pond.GetLength(0) - 1 ? pond.GetLength(0) - 1 : 0;

            }
            else if (command == "left")
            {
                startCol = startCol > 0 ? 0 : pond.GetLength(1) - 1;

            }
            else if (command == "right")
            {
                startCol = startCol < pond.GetLength(1) - 1 ? pond.GetLength(1) - 1 : 0;
            }

            if (char.IsLower(pond[startRow, startCol]))
            {
                branches.Add(pond[startRow, startCol]);
                totalBranchesCount--;
            }
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
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
