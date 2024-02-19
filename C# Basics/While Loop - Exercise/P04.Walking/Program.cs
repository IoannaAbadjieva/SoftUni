namespace P04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string input = "";

            while (sum < 10000)
            {
                input = Console.ReadLine();

                if (input == "Going home")
                {
                    sum += int.Parse(Console.ReadLine());
                    break;
                }

                sum += int.Parse(input);
            }
            if (sum >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sum - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - sum} more steps to reach goal.");
            }
        }
    }
}
