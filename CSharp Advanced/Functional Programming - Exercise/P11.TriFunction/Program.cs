namespace P11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkNameSum = (name, number) => name.Sum(ch => ch) >= number;

            Func<string[], int, Func<string, int, bool>, string> getFirstMatchingName = (names, number, match)
                => names.FirstOrDefault(name => match(name, number));

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(getFirstMatchingName(names, n, checkNameSum));
        }
    }
}
