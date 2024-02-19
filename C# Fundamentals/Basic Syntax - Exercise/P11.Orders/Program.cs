namespace P11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            double totalPrice = 0.0;

            for (int i = 1; i <= ordersCount; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int daysCount = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double orderPrice = daysCount * capsulesCount * capsulePrice;
                Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
                totalPrice += orderPrice;
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
