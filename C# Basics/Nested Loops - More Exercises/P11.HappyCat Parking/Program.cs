namespace P11.HappyCat_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalTax = 0.0;
            double tax;

            for (int d = 1; d <= days; d++)
            {
                tax = 0.0;
                for (int h = 1; h <= hours; h++)
                {
                    if (d % 2 == 0 && h % 2 != 0)
                    {
                        tax += 2.50;
                    }
                    else if (d % 2 != 0 && h % 2 == 0)
                    {
                        tax += 1.25;
                    }
                    else
                    {
                        tax += 1.0;
                    }
                }
                totalTax += tax;
                Console.WriteLine($"Day: {d} - {tax:f2} leva");
            }
            Console.WriteLine($"Total: {totalTax:f2} leva");
        }
    }
}
