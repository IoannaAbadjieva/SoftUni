namespace P04.Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<string, string> addVAT = x => $"{1.2 * double.Parse(x):f2}";

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(addVAT)));
        }
    }
}
