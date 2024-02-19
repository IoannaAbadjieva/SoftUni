namespace P02.Report_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumNeeded = int.Parse(Console.ReadLine());
            int sumCC = 0;
            int sumCS = 0;
            int countCC = 0;
            int countCS = 0;
            int counter = 0;


            string input = Console.ReadLine();
            while (input != "End")
            {
                int num = int.Parse(input);
                counter++;
                if (counter % 2 != 0 && num <= 100)
                {
                    Console.WriteLine("Product sold!");
                    countCS++;
                    sumCS += num;
                }
                else if (counter % 2 == 0 && num >= 10)
                {
                    Console.WriteLine("Product sold!");
                    countCC++;
                    sumCC += num;
                }
                else
                {
                    Console.WriteLine("Error in transaction!");
                }
                if ((sumCC + sumCS) >= sumNeeded)
                {
                    Console.WriteLine($"Average CS: {sumCS * 1.0 / countCS:f2}");
                    Console.WriteLine($"Average CC: {sumCC * 1.0 / countCC:f2}");
                    break;
                }
                input = Console.ReadLine();
            }

            if (input == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }

        }
    }
}
