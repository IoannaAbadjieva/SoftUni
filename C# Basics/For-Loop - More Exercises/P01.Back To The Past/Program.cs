namespace P01.Back_To_The_Past
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyInherited = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int n = year - 1800;
            double moneyNeeded = 0.0;

            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    moneyNeeded += 12000;
                }
                else
                {
                    moneyNeeded += 12000 + (i + 18) * 50;
                }
            }

            if (moneyNeeded <= moneyInherited)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyInherited - moneyNeeded:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {moneyNeeded - moneyInherited:f2} dollars to survive.");
            }

        }
    }
}
