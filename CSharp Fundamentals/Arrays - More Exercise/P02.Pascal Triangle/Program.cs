namespace P02.Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            for (int row = 0; row < n; row++)
            {
                triangle[row] = new long[row + 1];
            }

            triangle[0][0] = 1;

            for (int row = 0; row < n - 1; row++)
            {
                for (int column = 0; column <= row; column++)
                {
                    triangle[row + 1][column] += triangle[row][column];
                    triangle[row + 1][column + 1] += triangle[row][column];
                }
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(' ', triangle[row]));
            }

        }
    }
}
