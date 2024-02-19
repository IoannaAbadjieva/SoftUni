namespace P06.Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int c = 'a'; c < 'a' + n; c++)
            {
                for (int h = 'a'; h < 'a' + n; h++)
                {
                    for (int r = 'a'; r < 'a' + n; r++)
                    {
                        Console.WriteLine($"{(char)c}{(char)h}{(char)r}");
                    }
                }
            }
        }
    }
}
