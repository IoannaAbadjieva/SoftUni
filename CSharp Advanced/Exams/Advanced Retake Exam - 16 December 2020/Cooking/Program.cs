namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foodValues = new Dictionary<string, int>()
            {
                {"Bread",25},
                {"Cake",50},
                {"Pastry",75},
                {"Fruit Pie",100},
            };

            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                {"Bread",0},
                {"Cake",0},
                {"Pastry",0},
                {"Fruit Pie",0},
            };

            int[] liquidsValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ingredientsValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsValues);
            Stack<int> ingredients = new Stack<int>(ingredientsValues);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();

                int sumOfIngredients = liquid + ingredient;

                KeyValuePair<string, int> kvp = foodValues.FirstOrDefault(x => x.Value == sumOfIngredients);

                if (kvp.Key != null)
                {
                    food[kvp.Key]++;
                }
                else
                {
                    ingredients.Push(ingredient + 3);
                }
            }

            if (food.Any(f => f.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            string liquidsLeft = liquids.Count > 0 ? string.Join(", ", liquids) : "none";
            string ingredientsLeft = ingredients.Count > 0 ? string.Join(", ", ingredients) : "none";
            Console.WriteLine($"Liquids left: {liquidsLeft}");
            Console.WriteLine($"Ingredients left: {ingredientsLeft}");

            foreach (var kvp in food.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
