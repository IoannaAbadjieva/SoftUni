using System.Text.RegularExpressions;

namespace P01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> furnitures = new List<Furniture>();

            string pattern = @"[>]{2}(?<item>[A-Z]+[a-z]*)[<]{2}(?<price>[0-9]+(\.[0-9]+)?)!(?<qty>[0-9]+)\b";

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string item = match.Groups["item"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int qty = int.Parse(match.Groups["qty"].Value);

                    Furniture newFurniture = new Furniture(item, price, qty);
                    furnitures.Add(newFurniture);
                }
            }

            PrintFurnitureInfo(furnitures);
        }

        static void PrintFurnitureInfo(List<Furniture> furnitures)
        {
            Console.WriteLine("Bought furniture:");
            furnitures.ForEach(x => Console.WriteLine(x.Item));
            Console.WriteLine($"Total money spend: {furnitures.Sum(x => x.Qty * x.Price):f2}");
        }
    }

    class Furniture
    {
        public Furniture(string item, double price, int qty)
        {
            Item = item;
            Price = price;
            Qty = qty;
        }

        public string Item { get; set; }

        public double Price { get; set; }

        public int Qty { get; set; }
    }
}

