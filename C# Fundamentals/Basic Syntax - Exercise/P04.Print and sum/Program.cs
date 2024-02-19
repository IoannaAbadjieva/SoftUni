namespace P04.Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int sum = 0;
            string toPrint = string.Empty;

            for (int i = start; i <= end; i++)
            {
                toPrint += i.ToString() + " ";
                sum += i;
            }

            Console.WriteLine(toPrint);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
