namespace P03.Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstPointAbsc = double.Parse(Console.ReadLine());
            double firstPointOrd = double.Parse(Console.ReadLine());
            double secondPointAbsc = double.Parse(Console.ReadLine());
            double secondPointOrd = double.Parse(Console.ReadLine());
            double thirdPointAbsc = double.Parse(Console.ReadLine());
            double thirdPointOrd = double.Parse(Console.ReadLine());
            double fourthPointAbsc = double.Parse(Console.ReadLine());
            double fourthPointOrd = double.Parse(Console.ReadLine());

            PrintCoordinatesOfLongerLine(firstPointAbsc, firstPointOrd, secondPointAbsc, secondPointOrd,
                thirdPointAbsc, thirdPointOrd, fourthPointAbsc, fourthPointOrd);
        }

        static void PrintCoordinatesOfLongerLine(double x1, double y1, double x2, double y2,
            double x3, double y3, double x4, double y4)
        {
            if (GetLineLenght(x1, y1, x2, y2) >= GetLineLenght(x3, y3, x4, y4))
            {
                PrintCoordinates(x1, y1, x2, y2);
            }
            else
            {
                PrintCoordinates(x3, y3, x4, y4);
            }
        }

        static double GetLineLenght(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }

        static void PrintCoordinates(double x1, double y1, double x2, double y2)
        {
            if (GetDistance(x1, y1) <= GetDistance(x2, y2))
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }

        static double GetDistance(double absc, double ord)
        {
            return Math.Sqrt(Math.Pow(absc, 2) + Math.Pow(ord, 2));
        }
    }
}
