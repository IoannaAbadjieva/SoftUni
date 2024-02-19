namespace P04.Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int k = numbers.Length / 4;

            int[] foldedArray = new int[2 * k];
            int[] middleArray = new int[2 * k];
            int[] endsArray = new int[2 * k];

            for (int index = 0; index < 2 * k; index++)
            {
                middleArray[index] = numbers[index + k];
            }

            int endsArrayIndex = 0;

            for (int index = k - 1; index >= 0; index--)
            {
                endsArray[endsArrayIndex] = numbers[index];
                endsArrayIndex++;
            }

            for (int index = 4 * k - 1; index >= 3 * k; index--)
            {
                endsArray[endsArrayIndex] = numbers[index];
                endsArrayIndex++;
            }

            for (int index = 0; index < 2 * k; index++)
            {
                foldedArray[index] = middleArray[index] + endsArray[index];
            }

            Console.WriteLine(string.Join(' ', foldedArray));

        }
    }
}
