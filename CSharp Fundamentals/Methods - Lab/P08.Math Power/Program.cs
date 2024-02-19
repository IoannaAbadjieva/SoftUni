namespace P08.Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double @base = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double mathPower = RaiseToPower(@base, power);
            Console.WriteLine(mathPower);
        }

        static double RaiseToPower(double @base, int power)
        {
            double result = 1;

            for (int i = 1; i <= power; i++)
            {
                result *= @base;
            }
            return result;
        }
    }
}
