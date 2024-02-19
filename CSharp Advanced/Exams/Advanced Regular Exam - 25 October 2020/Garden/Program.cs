namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                List<string> flowers = new List<string>();

                int[] dimensions = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

                int[,] garden = new int[dimensions[0], dimensions[1]];

                string command;

                while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
                {
                    int row = int.Parse(command.Split(' ')[0]);
                    int col = int.Parse(command.Split(' ')[1]);

                    if (!IsIndicesValid(garden, row, col))
                    {
                        Console.WriteLine("Invalid coordinates.");
                        continue;
                    }

                    flowers.Add(command);
                }

                foreach (var flower in flowers)
                {
                    int row = int.Parse(flower.Split(' ')[0]);
                    int col = int.Parse(flower.Split(' ')[1]);

                    garden[row, col]++;

                    for (int c = 0; c < garden.GetLength(1); c++)
                    {
                        if (c != col)
                        {
                            garden[row, c]++;

                        }
                    }

                    for (int r = 0; r < garden.GetLength(1); r++)
                    {
                        if (r != row)
                        {
                            garden[r, col]++;

                        }
                    }
                }

                PrintMatrix(garden);
            }

            static bool IsIndicesValid(int[,] matrix, int row, int col)
            {
                return row >= 0 && row < matrix.GetLength(0)
                    && col >= 0 && col < matrix.GetLength(1);
            }

            static void PrintMatrix(int[,] matrix)
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
}
