namespace P03.Vacantion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price;
            double totalPrice = 0.0;

            switch (typeOfGroup)
            {
                case "Students":
                    if (dayOfWeek == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 9.80;
                    }
                    else
                    {
                        price = 10.46;
                    }

                    totalPrice = count * price;

                    if (count >= 30)
                    {
                        totalPrice *= 0.85;
                    }

                    break;

                case "Business":
                    if (dayOfWeek == "Friday")
                    {
                        price = 10.90;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 15.60;
                    }
                    else
                    {
                        price = 16.0;
                    }

                    if (count >= 100)
                    {
                        count -= 10;
                    }
                    totalPrice = count * price;
                    break;

                default:
                    if (dayOfWeek == "Friday")
                    {
                        price = 15.0;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 20.0;
                    }
                    else
                    {
                        price = 22.50;
                    }

                    totalPrice = count * price;

                    if (count >= 10 && count <= 20)
                    {
                        totalPrice *= 0.95;
                    }

                    break;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
