namespace P05.Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
          .Select(x => int.Parse(x))
          .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            char[] text = Console.ReadLine().ToCharArray();
            Queue<char> snake = new Queue<char>(text);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake.Dequeue();
                        snake.Enqueue(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake.Dequeue();
                        snake.Enqueue(matrix[row, col]);
                    }
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
