namespace P01.Pool_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double sunbedPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double sum = n * tax + Math.Ceiling(0.75 * n) * sunbedPrice + Math.Ceiling(n * 0.50) * umbrellaPrice;
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
