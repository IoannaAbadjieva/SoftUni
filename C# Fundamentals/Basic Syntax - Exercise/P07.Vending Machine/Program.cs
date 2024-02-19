namespace P07.Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double sum = 0.0;
            double price = 0.0;

            while ((input = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    continue;
                }
            }

            string product;
            while ((product = Console.ReadLine()) != "End")
            {
                if (product == "Nuts")
                {
                    price = 2.0;
                }
                else if (product == "Water")
                {
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {
                    price = 0.8;
                }
                else if (product == "Coke")
                {
                    price = 1.0;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }

                if (price > sum)
                {
                    Console.WriteLine($"Sorry, not enough money");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sum -= price;
                }
            }
            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
