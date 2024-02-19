namespace P07.School_Camp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine(); ;
            string group = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int stays = int.Parse(Console.ReadLine());

            double campPrice = 0.0;
            string sport = "";
            int totalStays = students * stays;

            switch (season)
            {
                case "Winter":
                    campPrice = totalStays * 9.60;
                    if (group == "girls")
                    {
                        sport = "Gymnastics";
                    }
                    else if (group == "boys")
                    {
                        sport = "Judo";
                    }
                    else
                    {
                        campPrice = totalStays * 10.0;
                        sport = "Ski";
                    }
                    break;

                case "Spring":
                    campPrice = totalStays * 7.20;
                    if (group == "girls")
                    {
                        sport = "Athletics";
                    }
                    else if (group == "boys")
                    {
                        sport = "Tennis";
                    }
                    else
                    {
                        campPrice = totalStays * 9.50;
                        sport = "Cycling";
                    }
                    break;

                case "Summer":
                    campPrice = totalStays * 15.0;
                    if (group == "girls")
                    {
                        sport = "Volleyball";
                    }
                    else if (group == "boys")
                    {
                        sport = "Football";
                    }
                    else
                    {
                        campPrice = totalStays * 20.0;
                        sport = "Swimming";
                    }
                    break;

            }
            if (students >= 50)
            {
                campPrice -= campPrice * 0.50;
            }
            else if (students >= 20)
            {
                campPrice -= campPrice * 0.15;
            }
            else if (students >= 10)
            {
                campPrice -= campPrice * 0.05;
            }

            Console.WriteLine($"{sport} {campPrice:F2} lv.");
        }
    }
}
