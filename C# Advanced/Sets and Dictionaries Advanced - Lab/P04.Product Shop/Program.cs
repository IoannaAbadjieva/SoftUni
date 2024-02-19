namespace P04.Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string product = Console.ReadLine();
                if (product == "Revision")
                {
                    break;
                }

                string[] productInfo = product.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = productInfo[0];
                string productName = productInfo[1];
                double price = double.Parse(productInfo[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops[shopName] = new Dictionary<string, double>();
                }
                shops[shopName][productName] = price;
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
