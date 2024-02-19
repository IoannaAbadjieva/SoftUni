namespace Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> locations = new SortedDictionary<string, int>();

            Dictionary<int, string> areas = new Dictionary<int, string>()
            {
                {40,"Sink" },
                {50,"Oven" },
                {60,"Countertop" },
                {70,"Wall" }
            };
            int[] whiteTiles = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] greyTiles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(whiteTiles);
            Queue<int> queue = new Queue<int>(greyTiles);

            while (stack.Count > 0 && queue.Count > 0)
            {
                int white = stack.Pop();
                int grey = queue.Dequeue();

                if (white == grey)
                {
                    int sumOfTiles = white + grey;
                    if (areas.ContainsKey(sumOfTiles))
                    {
                        if (!locations.ContainsKey(areas[sumOfTiles]))
                        {
                            locations.Add(areas[sumOfTiles], 0);
                        }
                        locations[areas[sumOfTiles]]++;
                    }
                    else
                    {
                        if (!locations.ContainsKey("Floor"))
                        {
                            locations.Add("Floor", 0);
                        }
                        locations["Floor"]++;
                    }
                }
                else
                {
                    stack.Push(white / 2);
                    queue.Enqueue(grey);
                }
            }

            string whitesLeft = stack.Count > 0 ? string.Join(", ", stack) : "none";
            string greysLeft = queue.Count > 0 ? string.Join(", ", queue) : "none";

            Console.WriteLine($"White tiles left: {whitesLeft}");
            Console.WriteLine($"Grey tiles left: {greysLeft}");

            foreach (var location in locations.OrderByDescending(l => l.Value))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
