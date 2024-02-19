namespace P03.Time_15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int sumTime = num1 * 60 + num2 + 15;
            int hour = sumTime / 60;
            int minutes = sumTime % 60;

            if (hour >= 24)
            {
                hour = hour - 24;
            }

            if (minutes < 10)
            {
                Console.WriteLine($"{hour}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hour}:{minutes}");
            }
        }
    }
}
