namespace P03.Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] chemicals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in chemicals)
                {
                    elements.Add(element);
                }
            }
            Console.WriteLine(String.Join(' ', elements));
        }
    }
}
