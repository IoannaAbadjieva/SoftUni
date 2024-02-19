namespace P03.Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num <= 3) p1 += num;
                else if (num <= 11) p2 += num;
                else p3 += num;
            }
            double total = p1 + p2 + p3;
            double average = (p1 * 200 + p2 * 175 + p3 * 120) / total;
            p1 = p1 * 100 / total;
            p2 = p2 * 100 / total;
            p3 = p3 * 100 / total;

            Console.WriteLine($"{average:f2}");
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
