namespace P10.Multiply_by_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPositive = true;
            do
            {
                double num = double.Parse(Console.ReadLine());
                if (num >= 0)
                {
                    Console.WriteLine($"Result: {num * 2:f2}");
                }
                else
                {
                    Console.WriteLine("Negative number!");
                    isPositive = false;
                }

            } while (isPositive);
        }
    }
}
