namespace P01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input;
            int winsCount = 0;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCount} won battles and {energy} energy");
                    return;
                }

                energy -= distance;
                winsCount++;

                if (winsCount % 3 == 0)
                {
                    energy += winsCount;
                }
            }

            Console.WriteLine($"Won battles: {winsCount}. Energy left: {energy}");
        }
    }
}
