namespace P01.Agency_Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string company = Console.ReadLine();
            int adultTicketsCount = int.Parse(Console.ReadLine());
            int childTicketsCount = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double adultTicketPrice = price + tax;
            double childTicketPrice = price * 0.30 + tax;
            double profit = (adultTicketsCount * adultTicketPrice + childTicketsCount * childTicketPrice) * 0.20;
            Console.WriteLine($"The profit of your agency from {company} tickets is {profit:f2} lv.");
        }
    }
}
