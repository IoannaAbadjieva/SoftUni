namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionIncrement = 1.4;

        public Bus(double fuelQuantuty, double fuelConsumption, double tankCapacity)
            : base(fuelQuantuty, fuelConsumption, tankCapacity)
        {

        }

        public bool IsEmpty { get; set; }

        protected override double FuelConsumtionIncrement
        {
            get
            {
                if (!this.IsEmpty)
                {
                    return BusFuelConsumptionIncrement;

                }

                return 0;
            }
        }

    }
}
