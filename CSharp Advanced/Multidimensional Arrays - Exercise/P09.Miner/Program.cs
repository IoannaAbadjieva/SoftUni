namespace P09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int startRow = 0;
            int startCol = 0;
            int coalsCount = 0;
            for (int row = 0; row < size; row++)
            {
                string[] rowElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (rowElements[col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (rowElements[col] == "c")
                    {
                        coalsCount++;
                    }
                }
            }

            int coalsCollected = 0;
            int currRow = startRow;
            int currCol = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "left")
                {
                    if (IsIndexValid(currCol - 1, size))
                    {
                        currCol--;
                    }
                }
                else if (command == "right")
                {
                    if (IsIndexValid(currCol + 1, size))
                    {
                        currCol++;
                    }
                }
                else if (command == "up")
                {
                    if (IsIndexValid(currRow - 1, size))
                    {
                        currRow--;
                    }
                }
                else if (command == "down")
                {
                    if (IsIndexValid(currRow + 1, size))
                    {
                        currRow++;
                    }
                }

                if (matrix[currRow, currCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                    return;
                }
                else if (matrix[currRow, currCol] == "c")
                {
                    coalsCollected++;
                    matrix[currRow, currCol] = "*";
                    if (coalsCollected == coalsCount)
                    {
                        Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{coalsCount - coalsCollected} coals left. ({currRow}, {currCol})");

        }

        static bool IsIndexValid(int index, int size)
        {
            return index >= 0 && index < size;
        }
    }
}
