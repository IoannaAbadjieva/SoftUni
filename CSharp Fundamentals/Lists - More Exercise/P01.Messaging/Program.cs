namespace P01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<char> sentense = Console.ReadLine().ToCharArray().ToList();

            PrintMessage(numbers, sentense);
        }



        static void PrintMessage(int[] numbers, List<char> sentense)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                int currNumber = numbers[index];
                int characterIndex = GetCharacterIndex(Math.Abs(currNumber));
                characterIndex %= sentense.Count;

                Console.Write(sentense[characterIndex]);
                sentense.RemoveAt(characterIndex);
            }
        }

        static int GetCharacterIndex(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                int currentDigit = num % 10;
                sum += currentDigit;
                num /= 10;
            }

            return sum;
        }
    }
}
