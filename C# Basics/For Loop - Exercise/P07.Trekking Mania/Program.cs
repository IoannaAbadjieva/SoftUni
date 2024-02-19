namespace P07.Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int trekkers = 0;
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;


            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                trekkers += num;

                if (num <= 5) p1 += num;

                else if (num <= 12) p2 += num;

                else if (num <= 25) p3 += num;

                else if (num <= 40) p4 += num;

                else p5 += num;

            }

            p1 = p1 * 100 / trekkers;
            p2 = p2 * 100 / trekkers;
            p3 = p3 * 100 / trekkers;
            p4 = p4 * 100 / trekkers;
            p5 = p5 * 100 / trekkers;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");

        }
    }
}
