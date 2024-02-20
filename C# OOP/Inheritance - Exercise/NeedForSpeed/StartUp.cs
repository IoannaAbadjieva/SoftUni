namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car passat = new Car(140, 64);
            passat.Drive(15);
            System.Console.WriteLine(passat.Fuel);

            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(60, 5);
            crossMotorcycle.Drive(3);
            System.Console.WriteLine(crossMotorcycle.Fuel);
        }
    }
}
