namespace P04.Food_for_Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double foodQuantity = double.Parse(Console.ReadLine());
            int dogFood = 0;
            int catFood = 0;
            double biscuits = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    biscuits += (num1 + num2) * 0.10;
                }
                dogFood += num1;
                catFood += num2;
            }
            double percentForPets = (dogFood + catFood) * 100 / foodQuantity;
            double percentForDog = dogFood * 100.0 / (dogFood + catFood);
            double percentForCat = catFood * 100.0 / (dogFood + catFood);

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{percentForPets:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentForDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentForCat:f2}% eaten from the cat.");

        }
    }
}
