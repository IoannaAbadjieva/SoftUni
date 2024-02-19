namespace P04.Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int count;
            int totalCount = 0;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 1; i <= groups; i++)
            {
                count = int.Parse(Console.ReadLine());
                totalCount += count;
                if (count <= 5) p1 += count;
                else if (count <= 12) p2 += count;
                else if (count <= 25) p3 += count;
                else if (count <= 40) p4 += count;
                else p5 += count;
            }

            p1 = p1 / totalCount * 100;
            p2 = p2 / totalCount * 100;
            p3 = p3 / totalCount * 100;
            p4 = p4 / totalCount * 100;
            p5 = p5 / totalCount * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
