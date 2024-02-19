namespace P09.Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stay = int.Parse(Console.ReadLine());
            string kindOfRoom = Console.ReadLine();
            string rating = Console.ReadLine();


            double staylPrice = 0.0;

            switch (kindOfRoom)
            {
                case "apartment":

                    staylPrice = (stay - 1) * 25;

                    if ((stay - 1) < 10)
                    {
                        staylPrice -= staylPrice * 0.30;
                    }
                    else if ((stay - 1) >= 10 && (stay - 1) <= 15)
                    {
                        staylPrice -= staylPrice * 0.35;
                    }
                    else if ((stay - 1) > 15)
                    {
                        staylPrice -= staylPrice * 0.5;
                    }
                    break;

                case "president apartment":
                    staylPrice = (stay - 1) * 35;

                    if ((stay - 1) < 10)
                    {
                        staylPrice -= staylPrice * 0.10;
                    }
                    else if ((stay - 1) >= 10 && (stay - 1) <= 15)
                    {
                        staylPrice -= staylPrice * 0.15;
                    }
                    else if ((stay - 1) > 15)
                    {
                        staylPrice -= staylPrice * 0.20;
                    }
                    break;

                default:
                    staylPrice = (stay - 1) * 18.0;
                    break;

            }

            if (rating == "positive")
            {
                staylPrice += staylPrice * 0.25;
            }
            else
            {
                staylPrice -= staylPrice * 0.10;
            }


            Console.WriteLine("{0:f2}", staylPrice);

        }
    }
}
