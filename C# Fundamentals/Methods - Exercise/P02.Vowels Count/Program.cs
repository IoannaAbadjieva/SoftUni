namespace P02.Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            int vowelsCount = GetVowelsCount(input);

            Console.WriteLine(vowelsCount);
        }

        static int GetVowelsCount(string str)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int counter = 0;

            foreach (char ch in str)
            {
                if (vowels.Contains(ch))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
