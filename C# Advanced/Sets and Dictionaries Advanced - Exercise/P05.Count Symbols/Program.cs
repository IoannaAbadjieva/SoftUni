namespace P05.Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charactersOccurencies = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var character in input)
            {
                if (!charactersOccurencies.ContainsKey(character))
                {
                    charactersOccurencies.Add(character, 0);
                }
                charactersOccurencies[character]++;
            }

            foreach (var kvp in charactersOccurencies)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
