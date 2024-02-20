
namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption
        {
            get { return DefaultFuelConsumption; }
        }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelLeft = Fuel -= kilometers * FuelConsumption;

            if (fuelLeft >= 0)
            {
                Fuel = fuelLeft;
            }

        }
    }
}
