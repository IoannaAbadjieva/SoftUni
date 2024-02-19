namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> bakeryQtys = new Dictionary<string, double[]>()
            {
                {"Croissant",new double[]{50,50 } },
                {"Muffin",new double[]{40,60 } },
                {"Baguette",new double[]{30,70 } },
                {"Bagel",new double[]{20,80 } },
            };

            Dictionary<string, int> bakery = new Dictionary<string, int>();

            double[] waterQtys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double[] flourQtys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Queue<double> water = new Queue<double>(waterQtys);
            Stack<double> flour = new Stack<double>(flourQtys);

            while (water.Count > 0 && flour.Count > 0)
            {
                double waterQty = water.Dequeue();
                double flourQty = flour.Pop();

                double waterPercentage = waterQty * 100 / (waterQty + flourQty);
                double flourPercentage = flourQty * 100 / (waterQty + flourQty);


                KeyValuePair<string, double[]> keyValuePair = bakeryQtys
                    .FirstOrDefault(kvp => kvp.Value[0] == waterPercentage && kvp.Value[1] == flourPercentage);


                if (keyValuePair.Key != null)
                {
                    if (!bakery.ContainsKey(keyValuePair.Key))
                    {
                        bakery.Add(keyValuePair.Key, 0);
                    }
                    bakery[keyValuePair.Key]++;
                }
                else
                {
                    if (!bakery.ContainsKey("Croissant"))
                    {
                        bakery.Add("Croissant", 0);
                    }
                    bakery["Croissant"]++;
                    flour.Push(flourQty - waterQty);
                }

            }

            foreach (var item in bakery.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            string waterLeft = water.Count > 0 ? string.Join(", ", water) : "None";
            string flourLeft = flour.Count > 0 ? string.Join(", ", flour) : "None";
            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }
    }
}
