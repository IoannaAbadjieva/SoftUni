namespace P06.Truck_Driver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmForMonth = double.Parse(Console.ReadLine());

            double salary = 4 * kmForMonth * 1.45;

            if (season == "Spring" || season == "Autumn")
            {
                if (kmForMonth <= 5000)
                {
                    salary = 4 * kmForMonth * 0.75;
                }
                else if (kmForMonth <= 10000)
                {
                    salary = 4 * kmForMonth * 0.95;
                }
            }
            else if (season == "Summer")
            {
                if (kmForMonth <= 5000)
                {
                    salary = 4 * kmForMonth * 0.90;
                }
                else if (kmForMonth <= 10000)
                {
                    salary = 4 * kmForMonth * 1.10;
                }
            }
            else
            {
                if (kmForMonth <= 5000)
                {
                    salary = 4 * kmForMonth * 1.05;
                }
                else if (kmForMonth <= 10000)
                {
                    salary = 4 * kmForMonth * 1.25;
                }
            }

            salary -= salary * 0.10;
            Console.WriteLine("{0:f2}", salary);
        }
    }
}
