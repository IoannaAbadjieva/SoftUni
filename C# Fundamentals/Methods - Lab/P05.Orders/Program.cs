namespace P05.Orders
{
    internal class Program
    {
        const double coffeePrice = 1.50;
        const double waterPrice = 1.00;
        const double cokePrice = 1.40;
        const double snacksPrice = 2.00;

        static void Main(string[] args)
        {

            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double price = GetProductPrice(product, quantity);
            Console.WriteLine($"{price:f2}");
        }

        static double GetProductPrice(string product, int quantity)
        {
            double price = 0.0;

            switch (product)
            {
                case "coffee":
                    price = coffeePrice * quantity;
                    break;
                case "water":
                    price = waterPrice * quantity;
                    break;
                case "coke":
                    price = cokePrice * quantity;
                    break;
                case "snacks":
                    price = snacksPrice * quantity;
                    break;
            }

            return price;

        }
    }
}
