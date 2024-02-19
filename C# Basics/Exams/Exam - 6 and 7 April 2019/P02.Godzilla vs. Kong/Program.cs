namespace P02.Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            double clothing = double.Parse(Console.ReadLine());

            if (count > 150)
            {
                clothing -= clothing * 0.10;
            }
            double costs = budget * 0.10 + count * clothing;

            if (budget >= costs)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {budget - costs:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {costs - budget:f2} leva more.");
            }
        }
    }
}
