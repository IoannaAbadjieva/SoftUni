namespace P05.Challenge_the_Wedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mеn = int.Parse(Console.ReadLine());
            int womеn = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            int counter = 0;
            bool isEnd = false;

            for (int i = 1; i <= mеn; i++)
            {
                for (int j = 1; j <= womеn; j++)
                {
                    Console.Write($"({i} <-> {j}) ");
                    counter++;
                    if (counter == tables)
                    {
                        isEnd = true;
                        break;
                    }
                }
                if (isEnd)
                {
                    break;
                }
            }
        }
    }
}
