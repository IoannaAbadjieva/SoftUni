namespace P06.The_Most_Powerful_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currWord = Console.ReadLine();
            int wordPower;
            int maxPower = 0;
            string mostPowerfulWord = "";
            string wordToLower;

            while (currWord != "End of words")
            {
                wordPower = 0;
                for (int i = 0; i < currWord.Length; i++)
                {
                    wordPower += currWord[i];
                }
                wordToLower = currWord.ToLower();
                switch (wordToLower[0])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                        wordPower = wordPower * currWord.Length;
                        break;
                    default:
                        wordPower = wordPower / currWord.Length;
                        break;
                }
                if (wordPower > maxPower)
                {
                    maxPower = wordPower;
                    mostPowerfulWord = currWord;
                }
                currWord = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxPower}");
        }
    }
}
