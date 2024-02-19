namespace P01.Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print(input);
        }
    }
}
