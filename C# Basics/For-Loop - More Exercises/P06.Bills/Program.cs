namespace P06.Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double electricity = 0;
            double other = 0;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                electricity += num;
                other += (num + 35) * 1.20;
            }
            double average = (electricity + n * 35 + other) / n;
            Console.WriteLine($"Electricity: {electricity:f2} lv");
            Console.WriteLine($"Water: {n * 20:f2} lv");
            Console.WriteLine($"Internet: {n * 15:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");
        }
    }
}
