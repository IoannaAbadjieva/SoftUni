namespace P03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> itemsPrice = new Dictionary<string, double>();
            Dictionary<string, int> itemsQty = new Dictionary<string, int>();
            Dictionary<string, double> orders = new Dictionary<string, double>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] itemInfo = input
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string itemName = itemInfo[0];
                double price = double.Parse(itemInfo[1]);
                int quantity = int.Parse(itemInfo[2]);

                itemsPrice[itemName] = price;

                if (!itemsQty.ContainsKey(itemName))
                {
                    itemsQty[itemName] = 0;
                }
                itemsQty[itemName] += quantity;

                orders[itemName] = itemsPrice[itemName] * itemsQty[itemName];
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
