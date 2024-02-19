namespace P04.Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> getEvens = x => x % 2 == 0;
            Predicate<int> getOdds = x => x % 2 != 0;


            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string filter = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            if (filter == "even")
            {
                numbers = numbers.FindAll(getEvens);
            }
            else
            {
                numbers = numbers.FindAll(getOdds);
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
