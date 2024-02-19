namespace P02.Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string inputString = Console.ReadLine();

            int sum = 0;
            int min = Math.Min(firstChar, secondChar);
            int max = Math.Max(firstChar, secondChar);

            foreach (char ch in inputString)
            {
                if (ch > min && ch < max)
                {
                    sum += ch;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
