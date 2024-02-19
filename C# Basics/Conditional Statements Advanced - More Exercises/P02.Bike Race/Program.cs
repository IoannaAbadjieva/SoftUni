namespace P02.Bike_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string route = Console.ReadLine();
            double sum = 0.0;


            switch (route)
            {
                case "trail":
                    sum = juniors * 5.50 + seniors * 7.0;
                    break;

                case "cross-country":
                    sum = juniors * 8.0 + seniors * 9.50;

                    if ((juniors + seniors) >= 50)
                    {
                        sum -= sum * 0.25;
                    }
                    break;

                case "downhill":
                    sum = juniors * 12.25 + seniors * 13.75;
                    break;

                case "road":
                    sum = juniors * 20.0 + seniors * 21.50;
                    break;
            }

            sum -= sum * 0.05;
            Console.WriteLine("{0:f2}", sum);
        }
    }
}
