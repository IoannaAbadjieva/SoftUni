namespace P03.Energy_Booster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double price = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (size == "small") price = quantity * 2 * 56.0;
                    else price = quantity * 5 * 28.70;
                    break;

                case "Mango":
                    if (size == "small") price = quantity * 2 * 36.66;
                    else price = quantity * 5 * 19.60;
                    break;

                case "Pineapple":
                    if (size == "small") price = quantity * 2 * 42.1;
                    else price = quantity * 5 * 24.80;
                    break;

                case "Raspberry":
                    if (size == "small") price = quantity * 2 * 20.0;
                    else price = quantity * 5 * 15.20;
                    break;
            }
            if (price > 1000)
            {
                price = price * 0.50;
            }
            else if (price >= 400)
            {
                price -= price * 0.15;
            }
            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
