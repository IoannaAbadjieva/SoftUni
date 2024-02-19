namespace P09.Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(IsPalindrom(input));
            }
        }

        static bool IsPalindrom(string num)
        {

            for (int index = 0; index < num.Length / 2; index++)
            {
                if (num[index] != num[num.Length - 1 - index])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
