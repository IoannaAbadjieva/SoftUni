namespace P10.Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokedTargetscount = 0;
            double halfPowerValue = power * 1.0 / 2;

            while (power >= distance)
            {
                power -= distance;
                pokedTargetscount++;

                if (power == halfPowerValue && exhaustionFactor != 0)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(pokedTargetscount);
        }
    }
}
