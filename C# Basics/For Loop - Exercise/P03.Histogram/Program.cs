namespace P03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;


            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200) p1++;

                else if (num < 400) p2++;

                else if (num < 600) p3++;

                else if (num < 800) p4++;

                else p5++;

            }

            p1 = p1 * 100 / n;
            p2 = p2 * 100 / n;
            p3 = p3 * 100 / n;
            p4 = p4 * 100 / n;
            p5 = p5 * 100 / n;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
