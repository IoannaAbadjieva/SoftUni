namespace P07.Vehicle_Catalogue
{
    class Program
    {
        public static object Cars { get; private set; }

        class Truck
        {
            public Truck(string brand, string model, int weight)
            {
                this.Brand = brand;
                this.Model = model;
                this.Weight = weight;

            }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }

        class Car
        {
            public Car(string brand, string model, int horsePower)
            {
                this.Brand = brand;
                this.Model = model;
                this.HorsePower = horsePower;

            }

            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }

        class Catalog
        {
            public Catalog()
            {
                this.Trucks = new List<Truck>();
                this.Cars = new List<Car>();
            }
            public List<Truck> Trucks { get; set; }
            public List<Car> Cars { get; set; }
        }

        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {

                string[] vehicleInfo = input
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];
                int weightOrPower = int.Parse(vehicleInfo[3]);

                if (type == "Truck")
                {
                    Truck newTruck = new Truck(brand, model, weightOrPower);
                    catalog.Trucks.Add(newTruck);
                }
                else if (type == "Car")
                {
                    Car newCar = new Car(brand, model, weightOrPower);
                    catalog.Cars.Add(newCar);
                }
            }

            PrintOrderedCars(catalog.Cars);
            PrintOrderedTrucks(catalog.Trucks);
        }

        static void PrintOrderedCars(List<Car> cars)
        {
            List<Car> orderedCars = cars.OrderBy(x => x.Brand).ToList();

            if (orderedCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
        }

        static void PrintOrderedTrucks(List<Truck> trucks)
        {
            List<Truck> orderedTrucks = trucks.OrderBy(x => x.Brand).ToList();

            if (orderedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
