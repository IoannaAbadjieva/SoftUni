namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                { "Datura Bombs",40},
                { "Cherry Bombs",60},
                { "Smoke Decoy Bombs",120}
            };

            SortedDictionary<string, int> bombsCreated = new SortedDictionary<string, int>()
            {
                { "Datura Bombs",0},
                { "Cherry Bombs",0},
                { "Smoke Decoy Bombs",0}
            };

            int[] bombsEffects = Console.ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            int[] bombsCasing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> effects = new Queue<int>(bombsEffects);
            Stack<int> casings = new Stack<int>(bombsCasing);

            while (effects.Count > 0 && casings.Count > 0)
            {
                int currEffect = effects.Peek();
                int currCasing = casings.Pop();

                int summary = currEffect + currCasing;

                KeyValuePair<string, int> bomb = bombs.FirstOrDefault(b => b.Value == summary);

                if (bomb.Key != null)
                {
                    bombsCreated[bomb.Key]++;
                    effects.Dequeue();

                    if (!bombsCreated.Any(b => b.Value < 3))
                    {
                        break;
                    }
                }
                else
                {
                    casings.Push(currCasing - 5);
                }
            }

            if (!bombsCreated.Any(b => b.Value < 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            string effectsLeft = effects.Count > 0 ? string.Join(", ", effects) : "empty";
            string casingsLeft = casings.Count > 0 ? string.Join(", ", casings) : "empty";

            Console.WriteLine($"Bomb Effects: {effectsLeft}");
            Console.WriteLine($"Bomb Casings: {casingsLeft}");

            foreach (var bomb in bombsCreated)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
