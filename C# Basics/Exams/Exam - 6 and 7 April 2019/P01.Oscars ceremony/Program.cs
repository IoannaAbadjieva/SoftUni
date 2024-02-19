namespace P01.Oscars_ceremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int roomRent = int.Parse(Console.ReadLine());
            double statues = roomRent * 0.70;
            double catering = statues * 0.85;
            double sound = catering * 0.50;

            double costs = roomRent + statues + catering + sound;
            Console.WriteLine("{0:f2}", costs);
        }
    }
}
