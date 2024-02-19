namespace P01.Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Random random = new Random();

            for (int index = 0; index < words.Length; index++)
            {
                int randomIndex = random.Next(0, words.Length);

                string currentWord = words[index];
                words[index] = words[randomIndex];
                words[randomIndex] = currentWord;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
