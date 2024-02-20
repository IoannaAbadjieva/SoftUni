namespace Vehicles.Models.Contracts
{
    public  interface IVehicle
    {
        double FuelQuantuty { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        string Drive(double distance);

        void Refuel(double qty);
    }
}
