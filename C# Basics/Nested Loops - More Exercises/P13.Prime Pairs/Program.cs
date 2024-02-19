namespace P13.Prime_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pair1From = int.Parse(Console.ReadLine());
            int pair2From = int.Parse(Console.ReadLine());
            int pair1To = pair1From + int.Parse(Console.ReadLine());
            int pair2To = pair2From + int.Parse(Console.ReadLine());
            bool isPrimePair1;
            bool isPrimePair2;

            for (int i = pair1From; i <= pair1To; i++)
            {
                isPrimePair1 = true;
                for (int x = 2; x < i; x++)
                {
                    if (i % x == 0)
                    {
                        isPrimePair1 = false;
                        break;
                    }
                }
                if (!isPrimePair1)
                {
                    continue;
                }
                for (int j = pair2From; j <= pair2To; j++)
                {
                    isPrimePair2 = true;
                    for (int y = 2; y < j; y++)
                    {
                        if (j % y == 0)
                        {
                            isPrimePair2 = false;
                            break;
                        }
                    }
                    if (!isPrimePair2)
                    {
                        continue;
                    }
                    Console.WriteLine($"{i}{j}");
                }

            }
        }
    }
}
