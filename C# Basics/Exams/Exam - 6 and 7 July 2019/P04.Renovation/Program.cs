namespace P04.Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());
            double area = Math.Ceiling(4 * a * b * (1 - percent / 100.0));
            int paint = 0;

            string input = Console.ReadLine();
            while (input != "Tired!")
            {
                paint += int.Parse(input);
                if (paint >= area)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if (paint > area)
            {
                Console.WriteLine($"All walls are painted and you have {paint - area} l paint left!");
            }
            else if (paint == area)
            {
                Console.WriteLine("All walls are painted! Great job, Pesho!");
            }
            else
            {
                Console.WriteLine($"{area - paint} quadratic m left.");
            }
        }
    }
}
