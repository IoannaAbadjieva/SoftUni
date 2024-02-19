namespace P06.Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            int topIntegerIndex = -1;

            for (int index = 0; index < numbers.Length; index++)
            {
                int leftSum = 0;
                for (int left = 0; left < index; left++)
                {
                    leftSum += numbers[left];
                }

                int rightSum = 0;
                for (int right = index + 1; right < numbers.Length; right++)
                {
                    rightSum += numbers[right];
                }

                if (leftSum == rightSum)
                {
                    topIntegerIndex = index;
                    break;
                }
            }

            if (topIntegerIndex != -1)
            {
                Console.WriteLine(topIntegerIndex);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
