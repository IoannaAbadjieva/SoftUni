namespace P05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = budget * 0.90;
            string destination = "Europe";
            string kindOfJourney = "Hotel";

            // budget<=100 lw. Bulgaria,Summer=> camp.,30% of budget, Winter=> hotel,70% of budget
            // budget<=1000 lw. Balkans,Summer=> camp.,40% of budget, Winter=> hotel,80% of budget
            // budget>1000 lw. Europe, hotel,90% of budget

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    kindOfJourney = "Camp";
                    price = budget * 0.30;
                }
                else
                {
                    kindOfJourney = "Hotel";
                    price = budget * 0.70;
                }

            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    kindOfJourney = "Camp";
                    price = budget * 0.40;
                }
                else
                {
                    kindOfJourney = "Hotel";
                    price = budget * 0.80;
                }
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{kindOfJourney} - {price:f2}");
        }
    }
}
