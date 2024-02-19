namespace P04.Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double escPrice = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());


            int toysCount = puzzleCount + dollsCount + bearsCount + minionsCount + trucksCount;
            double totalPrice = puzzleCount * 2.6 + dollsCount * 3 + bearsCount * 4.1 + minionsCount * 8.2 + trucksCount * 2;

            if (toysCount >= 50)
            {
                totalPrice = totalPrice * 0.75;
            }

            totalPrice = totalPrice * 0.9;

            double difference = totalPrice - escPrice;

            if (difference >= 0)
            {
                Console.WriteLine($"Yes! {difference:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(difference):f2} lv needed.");
            }
        }
    }
}
