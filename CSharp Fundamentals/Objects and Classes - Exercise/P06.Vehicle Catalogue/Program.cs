using System.Text;

namespace P06.Vehicle_Catalogue
{
    enum VehicleType
    {
        Car,
        Truck
    }

    //"{typeOfVehicle} {model} {color} {horsepower}"
    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public VehicleType Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {Type}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {Horsepower}");

            return sb.ToString().TrimEnd();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleArgs[0];
                string vehicleModel = vehicleArgs[1];
                string vehicleColor = vehicleArgs[2];
                int horsepower = int.Parse(vehicleArgs[3]);

                VehicleType vehicleType;
                bool isSuccessful = Enum.TryParse(type, true, out vehicleType);
                if (isSuccessful)
                {
                    Vehicle newVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, horsepower);
                    vehicles.Add(newVehicle);
                }

            }

            string model;
            while ((model = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle searchedVehicle = vehicles.FirstOrDefault(x => x.Model == model);
                if (searchedVehicle == null)
                {
                    continue;
                }
                Console.WriteLine(searchedVehicle);
            }

            double avgCarsHP = 0;
            List<Vehicle> cars = vehicles.Where(x => x.Type == VehicleType.Car).ToList();
            if (cars.Count > 0)
            {
                avgCarsHP = cars.Average(x => x.Horsepower);
            }


            double avgTrucksHP = 0;
            List<Vehicle> trucks = vehicles.Where(x => x.Type == VehicleType.Truck).ToList();
            if (trucks.Count > 0)
            {
                avgTrucksHP = trucks.Average(x => x.Horsepower);
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarsHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHP:f2}.");
        }
    }
}
