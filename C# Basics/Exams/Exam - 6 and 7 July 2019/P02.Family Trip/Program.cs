namespace P02.Family_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int stays = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            if (stays > 7) price = price * 0.95;
            double sumNeeded = stays * price + budget * percent / 100;


            if (budget >= sumNeeded)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - sumNeeded:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{sumNeeded - budget:f2} leva needed.");
            }
        }
    }
}
