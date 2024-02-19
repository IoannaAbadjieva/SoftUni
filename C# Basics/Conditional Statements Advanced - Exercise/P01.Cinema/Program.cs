namespace P01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double income = 0.0;

            switch (type)
            {
                case "Premiere":
                    income = rows * columns * 12.0;
                    break;
                case "Normal":
                    income = rows * columns * 7.50;
                    break;
                case "Discount":
                    income = rows * columns * 5.0;
                    break;
            }
            Console.WriteLine("{0:f2} leva", income);
        }
    }
}
