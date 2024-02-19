namespace P08.Equal_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxDiff = 0;

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int value = num1 + num2;

            for (int i = 2; i <= n; i++)
            {
                num1 = int.Parse(Console.ReadLine());
                num2 = int.Parse(Console.ReadLine());
                int cuurentValue = num1 + num2;
                if (cuurentValue != value)
                {
                    maxDiff = Math.Abs(value - cuurentValue);
                }
                value = cuurentValue;
            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={value}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }

        }
    }
}
