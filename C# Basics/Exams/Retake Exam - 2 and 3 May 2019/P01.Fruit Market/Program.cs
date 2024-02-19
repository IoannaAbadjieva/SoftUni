namespace P01.Fruit_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaQuantity = double.Parse(Console.ReadLine());
            double orangeQuantity = double.Parse(Console.ReadLine());
            double raspberryQuantity = double.Parse(Console.ReadLine());
            double strawberryQuantity = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice * 0.50;
            double orangePrice = raspberryPrice * 0.60;
            double bananaPrice = raspberryPrice * 0.20;

            double moneyNeeded = strawberryPrice * strawberryQuantity;
            moneyNeeded += bananaPrice * bananaQuantity;
            moneyNeeded += orangePrice * orangeQuantity;
            moneyNeeded += raspberryPrice * raspberryQuantity;

            Console.WriteLine("{0:f2}", moneyNeeded);
        }
    }
}
