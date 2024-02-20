namespace Vehicles.Models
{

    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double TruckRefuelCoefficient = 0.95;

        public Truck(double fuelQuantuty, double fuelConsumption, double tankCapacity)
            : base(fuelQuantuty, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumtionIncrement
            => TruckFuelConsumptionIncrement;

        protected override double RefuelCoefficient
            => TruckRefuelCoefficient;
    }
}
