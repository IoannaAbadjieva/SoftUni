namespace P05.Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] digits = input
                .Where(x => char.IsDigit(x))
                .ToArray();

            char[] letters = input
                .Where((x) => char.IsLetter(x))
                .ToArray();

            char[] otherCharacters = input
                .Where(x => !char.IsLetterOrDigit(x))
                .ToArray();

            Console.WriteLine(new String(digits));
            Console.WriteLine(new String(letters));
            Console.WriteLine(new String(otherCharacters));
        }
    }
}
