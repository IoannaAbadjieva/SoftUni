namespace P09.Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            List<int> removed = new List<int>();

            while (pokemons.Count > 0)
            {
                int pokemonIndex = int.Parse(Console.ReadLine());
                int elementValue;

                if (pokemonIndex < 0)
                {
                    elementValue = pokemons.First();
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons.Last());
                }
                else if (pokemonIndex >= pokemons.Count)
                {
                    elementValue = pokemons.Last();
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(pokemons.First());
                }
                else
                {
                    elementValue = pokemons[pokemonIndex];
                    pokemons.RemoveAt(pokemonIndex);
                }
                removed.Add(elementValue);
                IncreaseOrDecreaseElementsValues(pokemons, elementValue);
            }
            Console.WriteLine(removed.Sum());
        }

        static bool IsIndexValid(List<int> lst, int index)
        {
            return index >= 0 && index < lst.Count;
        }

        static void IncreaseOrDecreaseElementsValues(List<int> pokemons, int elementValue)
        {
            for (int index = 0; index < pokemons.Count; index++)
            {
                if (pokemons[index] > elementValue)
                {
                    pokemons[index] -= elementValue;
                }
                else
                {
                    pokemons[index] += elementValue;
                }
            }
        }
    }
}
