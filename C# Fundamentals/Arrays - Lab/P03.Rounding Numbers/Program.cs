namespace P03.Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray();

            int[] roundedNums = new int[numbers.Length];

            for (int index = 0; index < numbers.Length; index++)
            {
                roundedNums[index] = (int)Math.Round(numbers[index], MidpointRounding.AwayFromZero);
            }

            for (int index = 0; index < numbers.Length; index++)
            {
                Console.WriteLine($"{numbers[index]} => {roundedNums[index]}");
            }
        }
    }
}
