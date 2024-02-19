namespace P02.Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lenghts = Console.ReadLine().Split();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondtSet = new HashSet<int>();

            for (int i = 0; i < int.Parse(lenghts[0]); i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < int.Parse(lenghts[1]); i++)
            {
                secondtSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondtSet);
            Console.WriteLine(String.Join(' ', firstSet));
        }
    }
}
