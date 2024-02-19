namespace P01.Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] characters = Console.ReadLine()
               .Where(x => x != ' ')
               .ToArray();

            Dictionary<char, int> occurencies = new Dictionary<char, int>();

            foreach (var ch in characters)
            {
                if (occurencies.ContainsKey(ch))
                {
                    occurencies[ch]++;
                }
                else
                {
                    occurencies.Add(ch, 1);
                }
            }

            foreach (var item in occurencies)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
