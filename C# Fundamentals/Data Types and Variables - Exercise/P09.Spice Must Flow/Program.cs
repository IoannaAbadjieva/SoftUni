namespace P09.Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int daysCounter = 0;
            long harvest = 0L;


            if (yield >= 100)
            {
                while (yield >= 100)
                {
                    daysCounter++;
                    harvest += yield;
                    yield -= 10;
                }
                harvest -= (daysCounter + 1) * 26;
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(harvest);
        }
    }
}
