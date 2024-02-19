namespace P03.Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = x => char.IsUpper(x[0]);

            //Console.WriteLine(String.Join(Environment.NewLine,Console.ReadLine()
            //    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            //    .Where(x => isUpper(x))));

            Console.WriteLine(String.Join(Environment.NewLine, Array.FindAll(Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries), isUpper)));
        }
    }
}
