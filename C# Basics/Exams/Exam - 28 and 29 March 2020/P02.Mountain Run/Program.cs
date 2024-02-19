namespace P02.Mountain_Run
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secPerMeter = double.Parse(Console.ReadLine());

            double time = distance * secPerMeter;
            time += Math.Floor(distance / 50) * 30;

            if (time < record)
            {
                Console.WriteLine($"Yes! The new record is {time:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {time - record:f2} seconds slower.");
            }
        }
    }
}
