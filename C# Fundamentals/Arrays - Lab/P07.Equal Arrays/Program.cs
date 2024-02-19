namespace P07.Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int[] secondArray = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            bool isEqual = true;
            int sumOfElements = 0;

            for (int index = 0; index < firstArray.Length; index++)
            {
                if (firstArray[index] == secondArray[index])
                {
                    sumOfElements += firstArray[index];
                }
                else
                {
                    isEqual = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfElements}");
            }
        }
    }
}
