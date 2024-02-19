namespace P12.Trade_Commissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double percent = 0;

            if (sales > 0 && sales <= 500)
            {
                if (city == "Sofia")
                {
                    percent = 0.05;
                }
                else if (city == "Varna")
                {
                    percent = 0.045;
                }
                else if (city == "Plovdiv")
                {
                    percent = 0.055;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (sales > 500 && sales <= 1000)
            {
                if (city == "Sofia")
                {
                    percent = 0.07;
                }
                else if (city == "Varna")
                {
                    percent = 0.075;
                }
                else if (city == "Plovdiv")
                {
                    percent = 0.08;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (sales > 1000 && sales <= 10000)
            {
                if (city == "Sofia")
                {
                    percent = 0.08;
                }
                else if (city == "Varna")
                {
                    percent = 0.1;
                }
                else if (city == "Plovdiv")
                {
                    percent = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (sales > 10000)
            {
                if (city == "Sofia")
                {
                    percent = 0.12;
                }
                else if (city == "Varna")
                {
                    percent = 0.13;
                }
                else if (city == "Plovdiv")
                {
                    percent = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }

            }
            else
            {
                Console.WriteLine("error");
            }

            double commission = sales * percent;
            if (commission > 0)
            {
                Console.WriteLine("{0:f2}", commission);
            }

        }
    }
}
