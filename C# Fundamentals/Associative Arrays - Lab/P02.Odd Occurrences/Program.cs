namespace P02.Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> occurencies = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordToLower = word.ToLower();

                if (occurencies.ContainsKey(wordToLower))
                {
                    occurencies[wordToLower]++;
                }
                else
                {
                    occurencies.Add(wordToLower, 1);
                }
            }

            string[] result = occurencies
                .Where(x => x.Value % 2 != 0)
                .Select(x => x.Key)
                .ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
