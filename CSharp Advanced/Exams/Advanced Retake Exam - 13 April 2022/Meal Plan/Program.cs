namespace Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>()
           {
               { "salad",350},
               { "soup",490},
               { "pasta",680},
               { "steak",790},
           };

            string[] meals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] caloriesPerDay = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> queue = new Queue<string>(meals);
            Stack<int> stack = new Stack<int>(caloriesPerDay);
            int mealsCount = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                string meal = queue.Dequeue();
                mealsCount++;
                int mealCalories = mealsCalories[meal];
                int dailyCalories = stack.Pop();

                dailyCalories -= mealCalories;

                if (dailyCalories > 0)
                {
                    stack.Push(dailyCalories);
                }
                else if (dailyCalories < 0)
                {
                    if (stack.Count > 0)
                    {
                        stack.Push(stack.Pop() + dailyCalories);

                    }
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", queue)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", stack)} calories.");
            }
        }
    }
}
