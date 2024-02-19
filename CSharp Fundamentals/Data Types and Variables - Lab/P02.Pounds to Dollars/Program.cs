namespace P02.Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            double USD = pounds * 1.31;
            Console.WriteLine($"{USD:f3}");
        }
    }
}
