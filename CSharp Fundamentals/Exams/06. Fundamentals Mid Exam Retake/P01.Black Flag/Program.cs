namespace P01.Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double targetPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int day = 1; day <= days; day++)
            {
                totalPlunder += dailyPlunder;

                if (day % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }

                if (day % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.30;
                }

            }

            if (totalPlunder >= targetPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double percentage = totalPlunder / targetPlunder * 100;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }

        }
    }
}
