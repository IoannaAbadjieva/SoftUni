namespace P01.Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToList();

            for (int index = 0; index < numbers.Count - 1; index++)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    numbers[index] += numbers[index + 1];
                    numbers.RemoveAt(index + 1);
                    index = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
