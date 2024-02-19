namespace P01.Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalPrice = 0;

            while (input != "special" && input != "regular")
            {
                double currentPrice = double.Parse(input);

                if (currentPrice <= 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                totalPrice += currentPrice;
                input = Console.ReadLine();
            }

            double taxes = totalPrice * 0.20;
            double priceWithTaxes = totalPrice + taxes;

            if (input == "special")
            {
                priceWithTaxes -= 0.10 * priceWithTaxes;
            }

            if (priceWithTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {priceWithTaxes:f2}$");
            }
        }
    }
}
