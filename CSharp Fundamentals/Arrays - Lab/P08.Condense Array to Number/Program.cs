namespace P08.Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();



            while (numbers.Length > 1)
            {
                int[] condensed = new int[numbers.Length - 1];

                for (int index = 0; index < condensed.Length; index++)
                {
                    condensed[index] = numbers[index] + numbers[index + 1];
                }

                numbers = condensed;
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
