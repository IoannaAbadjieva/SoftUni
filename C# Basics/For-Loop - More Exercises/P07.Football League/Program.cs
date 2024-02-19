namespace P07.Football_League
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stadium = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;

            for (int i = 1; i <= fans; i++)
            {
                char section = char.Parse(Console.ReadLine());
                if (section == 'A') p1++;
                else if (section == 'B') p2++;
                else if (section == 'V') p3++;
                else p4++;
            }

            Console.WriteLine($"{p1 * 100 / fans:f2}%");
            Console.WriteLine($"{p2 * 100 / fans:f2}%");
            Console.WriteLine($"{p3 * 100 / fans:f2}%");
            Console.WriteLine($"{p4 * 100 / fans:f2}%");
            Console.WriteLine($"{fans * 100.0 / stadium:f2}%");

        }
    }
}
