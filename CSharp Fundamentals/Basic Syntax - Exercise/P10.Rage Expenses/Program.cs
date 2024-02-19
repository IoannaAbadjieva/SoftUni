namespace P10.Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());


            double expenses = count / 2 * headsetPrice
                + count / 3 * mousePrice
                + count / 6 * keyboardPrice
                + count / 12 * displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
