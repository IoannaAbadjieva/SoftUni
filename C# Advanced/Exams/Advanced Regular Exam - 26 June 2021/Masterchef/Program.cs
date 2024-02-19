namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> freshnessLevels = new Dictionary<string, int>()
            {
                { "Dipping sauce",150},
                { "Green salad",250},
                { "Chocolate cake",300},
                { "Lobster",400}
            };

            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce",0},
                { "Green salad",0},
                { "Chocolate cake",0},
                { "Lobster",0}
            };

            int[] ingredientValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] freshnessValues = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientValues);
            Stack<int> freshness = new Stack<int>(freshnessValues);

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currIngredient = ingredients.Dequeue();

                if (currIngredient == 0)
                {
                    continue;
                }

                int currFreshness = freshness.Pop();
                int totalFreshness = currFreshness * currIngredient;

                KeyValuePair<string, int> dish = freshnessLevels.FirstOrDefault(d => d.Value == totalFreshness);

                if (dish.Key == default)
                {
                    ingredients.Enqueue(currIngredient + 5);
                }
                else
                {
                    dishes[dish.Key]++;
                }
            }

            KeyValuePair<string, int> notMadedDish = dishes.FirstOrDefault(d => d.Value == 0);

            if (notMadedDish.Key != default)
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.Where(d => d.Value > 0).OrderBy(d => d.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
