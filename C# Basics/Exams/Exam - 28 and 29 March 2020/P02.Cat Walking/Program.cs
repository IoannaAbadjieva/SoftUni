namespace P02.Cat_Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = int.Parse(Console.ReadLine());
            int walks = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int caloriesBurned = min * 5 * walks;

            if (caloriesBurned >= calories * 0.50)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurned}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurned}.");
            }
        }
    }
}
