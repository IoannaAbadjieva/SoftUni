namespace P01.Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);


            int rows = int.Parse(size[0]);
            int columns = int.Parse(size[1]);
            int[,] matrix = new int[rows, columns];
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] rowElements = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = int.Parse(rowElements[col]);
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
