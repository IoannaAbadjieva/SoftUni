namespace P06.Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleOfString(input);
        }

        static void PrintMiddleOfString(string str)
        {
            if (str.Length % 2 != 0)
            {
                Console.WriteLine(str[str.Length / 2]);
            }
            else
            {
                Console.Write(str[str.Length / 2 - 1]);
                Console.WriteLine(str[str.Length / 2]);
            }
        }
    }
}
