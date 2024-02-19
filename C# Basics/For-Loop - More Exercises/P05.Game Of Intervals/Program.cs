namespace P05.Game_Of_Intervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double points = 0;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            double p6 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 0 && num <= 9)
                {
                    p1++;
                    points += num * 0.20;
                }
                else if (num >= 10 && num <= 19)
                {
                    p2++;
                    points += num * 0.30;
                }
                else if (num >= 20 && num <= 29)
                {
                    p3++;
                    points += num * 0.40;
                }
                else if (num >= 30 && num <= 39)
                {
                    p4++;
                    points += 50;
                }
                else if (num >= 40 && num <= 50)
                {
                    p5++;
                    points += 100;
                }
                else
                {
                    p6++;
                    points = points / 2;
                }

            }
            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {p1 * 100 / n:f2}%");
            Console.WriteLine($"From 10 to 19: {p2 * 100 / n:f2}%");
            Console.WriteLine($"From 20 to 29: {p3 * 100 / n:f2}%");
            Console.WriteLine($"From 30 to 39: {p4 * 100 / n:f2}%");
            Console.WriteLine($"From 40 to 50: {p5 * 100 / n:f2}%");
            Console.WriteLine($"Invalid numbers: {p6 * 100 / n:f2}%");
        }
    }
}
