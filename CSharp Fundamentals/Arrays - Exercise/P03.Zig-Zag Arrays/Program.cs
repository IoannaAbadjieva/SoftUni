namespace P03.Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int index = 0; index < n; index++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (index % 2 == 0)
                {
                    firstArray[index] = input[0];
                    secondArray[index] = input[1];
                }
                else
                {
                    firstArray[index] = input[1];
                    secondArray[index] = input[0];
                }

            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
