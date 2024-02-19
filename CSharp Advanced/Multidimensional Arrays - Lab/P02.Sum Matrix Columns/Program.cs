namespace P02.Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(", ");
            int rows = int.Parse(size[0]);
            int columns = int.Parse(size[1]);

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string[] rowElements = Console.ReadLine().Split(' ');

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = int.Parse(rowElements[col]);
                }
            }

            for (int col = 0; col < columns; col++)
            {
                int sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }

        }
    }
}
