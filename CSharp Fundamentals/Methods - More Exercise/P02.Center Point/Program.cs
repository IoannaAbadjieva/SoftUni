namespace P02.Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintCoordinatesOfClosestPoint(x1, y1, x2, y2);
        }

        static void PrintCoordinatesOfClosestPoint(double x1, double y1, double x2, double y2)
        {
            if (GetDistance(x1, y1) <= GetDistance(x2, y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        static double GetDistance(double abscissa, double ordinate)
        {
            return Math.Sqrt(Math.Pow(abscissa, 2) + Math.Pow(ordinate, 2));
        }
    }
}
