namespace P04.Raw_Data
{
    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }

        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }

        public string Type { get; set; }
    }

    class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
        }
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(newCar);
            }

            string command = Console.ReadLine();
            List<Car> filteredCars = FilterCars(cars, command);

            filteredCars.ForEach(x => Console.WriteLine(x.Model));
        }

        static List<Car> FilterCars(List<Car> cars, string filter)
        {
            List<Car> filteredCars = new List<Car>();

            if (filter == "fragile")
            {
                filteredCars = cars
                   .Where(x => x.Cargo.Type == filter && x.Cargo.Weight < 1000)
                   .ToList();
            }
            else if (filter == "flamable")
            {
                filteredCars = cars
                    .Where(x => x.Cargo.Type == filter && x.Engine.Power > 250)
                    .ToList();
            }

            return filteredCars;
        }
    }
}
