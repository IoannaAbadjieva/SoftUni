namespace P03.Coffee_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            double sum = 0.0;

            switch (sugar)
            {
                case "Without":
                    if (drink == "Espresso")
                    {
                        sum = n * 0.90;
                        if (n >= 5) sum -= sum * 0.25;
                    }
                    else if (drink == "Cappuccino") sum = n * 1.0;
                    else sum = n * 0.50;
                    sum -= sum * 0.35;
                    break;

                case "Normal":
                    if (drink == "Espresso")
                    {
                        sum = n * 1.0;
                        if (n >= 5) sum -= sum * 0.25;
                    }
                    else if (drink == "Cappuccino") sum = n * 1.20;
                    else sum = n * 0.60;
                    break;

                default:
                    if (drink == "Espresso")
                    {
                        sum = n * 1.20;
                        if (n >= 5) sum -= sum * 0.25;
                    }
                    else if (drink == "Cappuccino") sum = n * 1.60;
                    else sum = n * 0.70;
                    break;
            }

            if (sum > 15)
            {
                sum -= sum * 0.20;
            }
            Console.WriteLine($"You bought {n} cups of {drink} for {sum:f2} lv.");

        }
    }
}
