namespace P03.Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfSynonims = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < countOfSynonims; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonyms.ContainsKey(word))
                {
                    synonyms[word].Add(synonym);
                }
                else
                {
                    synonyms.Add(word, new List<string>() { synonym });
                }
            }

            foreach (var item in synonyms)
            {
P01.Count Chars in a String                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
