namespace P05.Care_of_Puppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine()) * 1000;
            int foodNeeded = 0;

            string input = Console.ReadLine();
            while (input != "Adopted")
            {
                foodNeeded += int.Parse(input);
                input = Console.ReadLine();
            }

            if (food >= foodNeeded)
            {
                Console.WriteLine($"Food is enough! Leftovers: {food - foodNeeded} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {foodNeeded - food} grams more.");
            }
        }
    }
}
