namespace P03.New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int flowersQuantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;

            switch (flowers)
            {
                case "Roses":
                    if (flowersQuantity <= 80)
                    {
                        price = flowersQuantity * 5.0;
                    }
                    else
                    {
                        price = flowersQuantity * 5.0 * 0.9;
                    }
                    break;

                case "Dahlias":
                    if (flowersQuantity <= 90)
                    {
                        price = flowersQuantity * 3.80;
                    }
                    else
                    {
                        price = flowersQuantity * 3.8 * 0.85;
                    }
                    break;

                case "Tulips":
                    if (flowersQuantity <= 80)
                    {
                        price = flowersQuantity * 2.8;
                    }
                    else
                    {
                        price = flowersQuantity * 2.8 * 0.85;
                    }
                    break;

                case "Narcissus":
                    if (flowersQuantity < 120)
                    {
                        price = flowersQuantity * 3.0 * 1.15;
                    }
                    else
                    {
                        price = flowersQuantity * 3.0;
                    }
                    break;

                case "Gladiolus":
                    if (flowersQuantity < 80)
                    {
                        price = flowersQuantity * 2.5 * 1.2;
                    }
                    else
                    {
                        price = flowersQuantity * 2.5;
                    }
                    break;
            }

            double difference = budget - price;
            if (difference >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersQuantity} {flowers} and {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(difference):f2} leva more.");
            }
        }
    }
}
