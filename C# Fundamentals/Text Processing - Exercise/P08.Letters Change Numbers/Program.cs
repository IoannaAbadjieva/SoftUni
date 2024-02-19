namespace P08.Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string word in inputLine)
            {
                sum += GetSingleWordSum(word);
            }

            Console.WriteLine($"{sum:f2}");
        }

        static int GetLetterAlphabetPosition(char letter)
        {
            letter = char.ToLower(letter);
            return letter - 96;
        }

        static double GetSingleWordSum(string word)
        {
            double sum = 0;
            char firstLetter = word.First();
            char lastLetter = word.Last();
            int number = int.Parse(word.Substring(1, word.Length - 2));

            int firstLetterPosition = GetLetterAlphabetPosition(firstLetter);
            int lastLetterPosition = GetLetterAlphabetPosition(lastLetter);

            if (char.IsUpper(firstLetter))
            {
                sum += (double)number / firstLetterPosition;
            }
            else if (char.IsLower(firstLetter))
            {
                sum += (double)number * firstLetterPosition;
            }

            if (char.IsUpper(lastLetter))
            {
                sum -= lastLetterPosition;
            }
            else if (char.IsLower(lastLetter))
            {
                sum += lastLetterPosition;
            }
            return sum;
        }
    }
}
