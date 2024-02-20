namespace Vehicles.Models
{

    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;

        public Car(double fuelQuantuty, double fuelConsumption, double tankCapacity)
            : base(fuelQuantuty, fuelConsumption, tankCapacity)
        {

        }

       
        protected override double FuelConsumtionIncrement
            => CarFuelConsumptionIncrement;
    }
}
