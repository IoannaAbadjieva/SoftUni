namespace P02.Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
      .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstWord = words[0];
            string secondWord = words[1];
            int biggerLenght = Math.Max(firstWord.Length, secondWord.Length);

            int sum = 0;
            for (int i = 0; i < biggerLenght; i++)
            {
                if (i < firstWord.Length && i < secondWord.Length)
                {
                    sum += firstWord[i] * secondWord[i];
                    continue;
                }

                if (i < firstWord.Length)
                {
                    sum += firstWord[i];
                }
                else if (i < secondWord.Length)
                {
                    sum += secondWord[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
