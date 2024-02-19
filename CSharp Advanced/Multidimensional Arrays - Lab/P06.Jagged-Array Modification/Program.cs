namespace P06.Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = command.Split(' ');

                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (!IsRowValid(matrix, row) || !IsColumnValid(matrix, row, col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (cmdType == "add")
                {
                    matrix[row][col] += value;
                }
                else if (cmdType == "subtract")
                {
                    matrix[row][col] -= value;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }

        static bool IsColumnValid(int[][] matrix, int row, int col)
        {
            return col >= 0 && col < matrix[row].Length;
        }

        static bool IsRowValid(int[][] matrix, int row)
        {
            return row >= 0 && row < matrix.Length;
        }
    }
}
