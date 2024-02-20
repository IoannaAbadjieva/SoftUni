namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double RaceMotorcycleDefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
             : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption
        {
            get { return RaceMotorcycleDefaultFuelConsumption; }
        }
    }
}
