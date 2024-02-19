namespace P03.Travel_Agency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string type = Console.ReadLine();
            string isVIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0.0;
            bool inValid = false;

            if (days > 7) days--;

            if (city == "Bansko" || city == "Borovets")
            {
                if (type == "noEquipment")
                {
                    price = days * 80;
                    if (isVIP == "yes") price -= price * 0.05;
                }
                else if (type == "withEquipment")
                {
                    price = days * 100;
                    if (isVIP == "yes") price -= price * 0.10;
                }
                else inValid = true;
            }
            else if (city == "Varna" || city == "Burgas")
            {
                if (type == "noBreakfast")
                {
                    price = days * 100;
                    if (isVIP == "yes") price -= price * 0.07;
                }
                else if (type == "withBreakfast")
                {
                    price = days * 130;
                    if (isVIP == "yes") price -= price * 0.12;
                }
                else inValid = true;

            }
            else inValid = true;

            if (inValid)
            {
                Console.WriteLine("Invalid input!");
            }
            else if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                Console.WriteLine($"The price is {price:f2}lv! Have a nice time!");
            }
        }
    }
}
