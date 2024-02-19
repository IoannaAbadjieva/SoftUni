namespace P07.Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[], Predicate<string>> printNames = (names, match) =>
            {
                foreach (string name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            printNames(names, x => x.Length <= lenght);

        }
    }
}
