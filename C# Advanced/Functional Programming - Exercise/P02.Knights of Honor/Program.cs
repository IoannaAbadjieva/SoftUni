namespace P02.Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[], string> print = (names, title) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print(input, "Sir");
        }
    }
}
