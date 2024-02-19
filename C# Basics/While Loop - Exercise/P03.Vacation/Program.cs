namespace P03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());

            int daysCounter = 0;
            int spendCounter = 0;
            string command = "";
            double money = 0.0;

            while (ownedMoney < neededMoney && spendCounter < 5)
            {
                command = Console.ReadLine();
                money = double.Parse(Console.ReadLine());
                daysCounter++;

                if (command == "save")
                {
                    spendCounter = 0;
                    ownedMoney += money;
                }
                else
                {
                    spendCounter++;
                    ownedMoney -= money;
                    if (ownedMoney < 0)
                    {
                        ownedMoney = 0;
                    }
                }
            }

            if (spendCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            if (ownedMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
