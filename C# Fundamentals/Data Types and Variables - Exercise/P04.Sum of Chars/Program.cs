namespace P04.Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfChCodes = 0;

            for (int i = 0; i < n; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                sumOfChCodes += ch;
            }

            Console.WriteLine($"The sum equals: {sumOfChCodes}");
        }
    }
}
