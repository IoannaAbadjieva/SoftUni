namespace P03.Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();


            List<int> second = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            List<int> result = new List<int>();

            int count = Math.Max(first.Count, second.Count);

            for (int index = 0; index < count; index++)
            {
                if (index < first.Count)
                {
                    result.Add(first[index]);
                }

                if (index < second.Count)
                {
                    result.Add(second[index]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
