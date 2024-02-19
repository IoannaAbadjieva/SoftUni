namespace P05.Average_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i = 1;
            int sum = 0;

            while (i <= n)
            {
                sum += int.Parse(Console.ReadLine());
                i++;
            }

            double average = sum * 1.0 / n;
            Console.WriteLine("{0:f2}", average);
        }
    }
}
