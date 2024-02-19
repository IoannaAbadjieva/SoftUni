namespace P06.Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length - 1; i++)
            {
                char currCh = text[i];
                if (text[i + 1] == currCh)
                {
                    text = text.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}
