namespace P08.List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int n = int.Parse(Console.ReadLine());
            HashSet<int> dividers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToHashSet();

            int[] numbers = Enumerable.Range(1, n).ToArray();

            foreach (int divider in dividers)
            {
                predicates.Add(x => x % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
