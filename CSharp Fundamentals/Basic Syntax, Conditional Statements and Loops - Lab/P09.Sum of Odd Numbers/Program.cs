namespace P09.Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                int currentOddNumber = 2 * i + 1;
                Console.WriteLine(currentOddNumber);
                sum += currentOddNumber;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
