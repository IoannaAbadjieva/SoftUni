namespace P01.Match_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());


            double ticketsPrice = 0.0;
            double transportCosts = 0.0;

            if (category == "VIP")
            {
                ticketsPrice = number * 499.99;
            }
            else
            {
                ticketsPrice = number * 249.99;
            }

            if (number < 5)
            {
                transportCosts = budget * 0.75;
            }
            else if (number < 10)
            {
                transportCosts = budget * 0.60;
            }
            else if (number < 25)
            {
                transportCosts = budget * 0.50;
            }
            else if (number < 50)
            {
                transportCosts = budget * 0.40;
            }
            else
            {
                transportCosts = budget * 0.25;
            }

            double allCosts = transportCosts + ticketsPrice;

            if ((budget - allCosts) >= 0)
            {
                Console.WriteLine($"Yes! You have {budget - allCosts:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {allCosts - budget:f2} leva.");
            }


        }
    }
}
