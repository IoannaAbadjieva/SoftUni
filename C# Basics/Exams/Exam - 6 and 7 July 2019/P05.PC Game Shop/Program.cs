namespace P05.PC_Game_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;

            for (int i = 1; i <= n; i++)
            {
                string game = Console.ReadLine();

                if (game == "Hearthstone") p1++;
                else if (game == "Fornite") p2++;
                else if (game == "Overwatch") p3++;
                else p4++;
            }
            p1 = p1 / n * 100;
            p2 = p2 / n * 100;
            p3 = p3 / n * 100;
            p4 = p4 / n * 100;
            Console.WriteLine($"Hearthstone - {p1:f2}%");
            Console.WriteLine($"Fornite - {p2:f2}%");
            Console.WriteLine($"Overwatch - {p3:f2}%");
            Console.WriteLine($"Others - {p4:f2}%");
        }
    }
}
