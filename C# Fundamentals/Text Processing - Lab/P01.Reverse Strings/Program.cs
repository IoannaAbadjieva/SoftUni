namespace P01.Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word;
            while ((word = Console.ReadLine()) != "end")
            {
                char[] wordToReverse = word.ToCharArray();
                Array.Reverse(wordToReverse);

                Console.WriteLine($"{word} = {new string(wordToReverse)}");
            }
        }
    }
}
