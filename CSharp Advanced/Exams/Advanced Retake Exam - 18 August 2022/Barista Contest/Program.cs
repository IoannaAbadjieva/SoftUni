namespace Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> qtysNeeded = new Dictionary<int, string>()
            {
                { 50,"Cortado"},
                { 75,"Espresso"},
                { 100,"Capuccino"},
                { 150,"Americano"},
                { 200,"Latte"}
            };

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            int[] coffeeQtys = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> coffee = new Queue<int>(coffeeQtys);

            int[] milkQtys = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> milk = new Stack<int>(milkQtys);

            //Console.WriteLine(qtysNeeded[50]);

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int coffeeQty = coffee.Dequeue();
                int milkQty = milk.Pop();

                if (qtysNeeded.ContainsKey(coffeeQty + milkQty))
                {
                    string drink = qtysNeeded[coffeeQty + milkQty];

                    if (!drinks.ContainsKey(drink))
                    {
                        drinks.Add(drink, 0);
                    }

                    drinks[drink]++;
                }
                else
                {
                    milk.Push(milkQty - 5);
                }
            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            string cofeeLeft = coffee.Count > 0 ? string.Join(", ", coffee) : "none";
            string milkLeft = milk.Count > 0 ? string.Join(", ", milk) : "none";
            Console.WriteLine($"Coffee left: {cofeeLeft}");
            Console.WriteLine($"Milk left: {milkLeft}");

            foreach (var drink in drinks.OrderBy(d => d.Value).ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
