namespace P03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
      .Select(int.Parse)
      .ToList();

            List<int> topNumbers = new List<int>();

            double average = numbers.Average();
            topNumbers = numbers.FindAll(x => x > average);
            topNumbers.Sort();
            topNumbers.Reverse();

            if (topNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (topNumbers.Count <= 5)
            {
                Console.WriteLine(string.Join(" ", topNumbers));
            }
            else
            {
                for (int index = 0; index < 5; index++)
                {
                    Console.Write($"{topNumbers[index]} ");
                }
            }
        }
    }
}
