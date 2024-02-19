namespace Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> words = new Dictionary<string, int[]>()
            {
                { "pear",new int[4] },
                { "flour",new int[5] },
                { "pork",new int[4] },
                { "olive",new int[5] },
            };

            string[] vowelletters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] consonantletters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<string> vowels = new Queue<string>(vowelletters);
            Stack<string> consonants = new Stack<string>(consonantletters);

            while (consonants.Count > 0)
            {
                string vowel = vowels.Dequeue();
                string consonant = consonants.Pop();


                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel))
                    {
                        int index = word.Key.IndexOf(vowel);
                        word.Value[index] = 1;
                    }
                }

                foreach (var word in words)
                {
                    if (word.Key.Contains(consonant))
                    {
                        int index = word.Key.IndexOf(consonant);
                        word.Value[index] = 1;
                    }
                }

                vowels.Enqueue(vowel);
            }

            Dictionary<string, int[]> foundWords = words
                .Where(w => w.Key.Length == w.Value.Sum())
                .ToDictionary(w => w.Key, w => w.Value);

            Console.WriteLine($"Words found: {foundWords.Count} ");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word.Key);
            }
        }
    }
}
