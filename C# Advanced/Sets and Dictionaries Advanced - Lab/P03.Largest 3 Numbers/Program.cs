namespace P03.Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            int[] sortedNumbers = numbers.OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(String.Join(' ', sortedNumbers));
        }
    }
}
