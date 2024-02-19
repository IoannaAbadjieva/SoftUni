namespace P06.World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secPerMeter = double.Parse(Console.ReadLine());

            double delay = Math.Floor(distance / 15) * 12.5;
            double swimmTime = distance * secPerMeter + delay;

            double difference = record - swimmTime;

            if (difference > 0)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {swimmTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {Math.Abs(difference):f2} seconds slower.");
            }
        }
    }
}
