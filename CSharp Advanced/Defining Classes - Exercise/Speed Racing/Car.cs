using System;


namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;

            FuelAmount = fuelAmount;

            FuelConsumptionPerKilometer = fuelConsumption;

        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }


        public void Drive(double distance)
        {
            double fuelLeft = FuelAmount - distance* FuelConsumptionPerKilometer;

            if (fuelLeft < 0)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            FuelAmount = fuelLeft;
            TravelledDistance += distance;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
