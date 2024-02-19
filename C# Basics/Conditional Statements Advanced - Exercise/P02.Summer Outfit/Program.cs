namespace P02.Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int degrees = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();
            string outfit = "Shirt";
            string shoes = "Moccasins";

            if (partOfDay == "Morning")
            {
                if (degrees <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (degrees >= 25)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }

            }
            else if (partOfDay == "Afternoon")
            {
                if (degrees > 18 && degrees <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (degrees >= 25)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
