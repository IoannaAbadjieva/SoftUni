namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> swordsResources = new Dictionary<string, int>()
            {
                {"Gladius",70 },
                {"Shamshir",80 },
                {"Katana",90 },
                {"Sabre",110 },
                {"Broadsword",150 }
            };

            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                {"Gladius",0 },
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }
            };

            int[] steelQtys = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] carbonQtys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> steel = new Queue<int>(steelQtys);
            Stack<int> carbon = new Stack<int>(carbonQtys);

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int steelQty = steel.Dequeue();
                int carbonQty = carbon.Pop();

                KeyValuePair<string, int> kvp = swordsResources.FirstOrDefault(s => s.Value == steelQty + carbonQty);
                if (kvp.Key == null)
                {
                    carbon.Push(carbonQty + 5);
                }
                else
                {
                    swords[kvp.Key]++;
                }
            }

            swords = swords
                .Where(s => s.Value > 0)
                .ToDictionary(s => s.Key, s => s.Value);

            string steelLeft = steel.Count > 0 ? string.Join(", ", steel) : "none";
            string carbonlLeft = carbon.Count > 0 ? string.Join(", ", carbon) : "none";

            if (swords.Count == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {swords.Sum(s => s.Value)} swords.");
            }

            Console.WriteLine($"Steel left: {steelLeft}");
            Console.WriteLine($"Carbon left: {carbonlLeft}");

            foreach (var sword in swords.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
