namespace P01.Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double petWeight = double.Parse(Console.ReadLine());

            int daysCounter = 0;

            while (daysCounter < 30)
            {
                daysCounter++;

                food -= 0.3;

                if (daysCounter % 2 == 0)
                {
                    hay -= 0.05 * food;
                }

                if (daysCounter % 3 == 0)
                {
                    cover -= petWeight / 3;
                }

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
        }
    }
}
