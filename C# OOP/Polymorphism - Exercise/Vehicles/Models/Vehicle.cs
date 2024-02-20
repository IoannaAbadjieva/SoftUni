namespace Vehicles.Models
{
    using Contracts;
    using Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private const double VehicleRefuelCoefficient = 1;

        private double fuelQuantity;

        protected Vehicle(double fuelQuantuty, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantuty = fuelQuantuty;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantuty
        {
            get { return this.fuelQuantity; }

            private set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }


        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        protected virtual double FuelConsumtionIncrement { get; }

        protected virtual double RefuelCoefficient => VehicleRefuelCoefficient;

        public string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + FuelConsumtionIncrement);

            if (fuelNeeded > this.FuelQuantuty)
            {
                throw new InsufficientFuelException(string.Format
                    (ExceptionMessages.InsufficientFuelExceptionMessage, this.GetType().Name));
            }

            this.FuelQuantuty -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }


        public void Refuel(double qty)
        {
            if (qty <= 0)
            {
                throw new InvalidFuelQuantityException();
            }

            double totalFuelQty = this.FuelQuantuty + qty * this.RefuelCoefficient;

            if (totalFuelQty > this.TankCapacity)
            {
                throw new InsufficientTankCapacityException(string.Format
                    (ExceptionMessages.InsufficientTankCapacityExceptionMessage, qty));
            }

            this.fuelQuantity = totalFuelQty;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantuty:f2}";
        }
    }
}
