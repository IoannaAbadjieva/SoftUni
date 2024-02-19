namespace P02.Add_Bags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double luggagePrice = double.Parse(Console.ReadLine());
            double luggageWeight = double.Parse(Console.ReadLine());
            int daysLeft = int.Parse(Console.ReadLine());
            int luggageCount = int.Parse(Console.ReadLine());

            double price = 0;


            if (luggageWeight < 10) price = luggagePrice * 0.20;
            else if (luggageWeight <= 20) price = luggagePrice * 0.50;
            else price = luggagePrice;

            if (daysLeft > 30) price += price * 0.10;
            else if (daysLeft >= 7) price += price * 0.15;
            else price += price * 0.40;

            Console.WriteLine($"The total price of bags is: {price * luggageCount:f2} lv.");
        }
    }
}
