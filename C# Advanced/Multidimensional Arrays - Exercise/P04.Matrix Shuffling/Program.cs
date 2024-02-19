namespace P04.Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                      .Select(x => int.Parse(x))
                      .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (!IsCommandValid(matrix, cmdArgs))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string tempValue = matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])];
                matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])] = matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])];
                matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])] = tempValue;

                PrintMatrix(matrix);
            }
        }

        static bool IsCommandValid(string[,] matrix, string[] cmdArgs)
        {

            return cmdArgs.Length == 5 && cmdArgs[0] == "swap" &&
                int.Parse(cmdArgs[1]) >= 0 && int.Parse(cmdArgs[1]) < matrix.GetLength(0) &&
                int.Parse(cmdArgs[2]) >= 0 && int.Parse(cmdArgs[2]) < matrix.GetLength(1) &&
                int.Parse(cmdArgs[3]) >= 0 && int.Parse(cmdArgs[3]) < matrix.GetLength(0) &&
                int.Parse(cmdArgs[4]) >= 0 && int.Parse(cmdArgs[4]) < matrix.GetLength(1);
        }

        static void PrintMatrix(string[,] matrix)
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
