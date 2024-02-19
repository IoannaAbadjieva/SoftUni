namespace P05.Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statCount = int.Parse(Console.ReadLine());
            double costumesPrice = double.Parse(Console.ReadLine());

            double costumesTotal = statCount * costumesPrice;

            if (statCount > 150)
            {
                costumesTotal = costumesTotal * 0.9;
            }

            double totalPrice = budget * 0.1 + costumesTotal;
            double difference = budget - totalPrice;

            if (difference < 0)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(difference):f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {difference:f2} leva left.");
            }
        }
    }
}
