namespace P04.Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                PrintTriangle(n);
            }

            static void PrintLine(int start, int end)
            {
                for (int i = start; i <= end; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            static void PrintTriangle(int col)
            {
                for (int i = 1; i < col; i++)
                {
                    PrintLine(1, i);
                }

                for (int i = col; i >= 1; i--)
                {
                    PrintLine(1, i);
                }
            }
        }
    }
}
