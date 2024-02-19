namespace P03.Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double consumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            Consumption = consumption;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double Consumption { get; set; }

        public double DistanceTraveled { get; set; }

        public void DriveADistance(int distance)
        {
            double fuelNeeded = distance * Consumption;

            if (fuelNeeded <= this.FuelAmount)
            {
                FuelAmount -= fuelNeeded;
                DistanceTraveled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {DistanceTraveled}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            AddCars(cars, n);
            Drive(cars);

            cars.ForEach(x => Console.WriteLine(x));
        }

        static void AddCars(List<Car> cars, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double consumption = double.Parse(carInfo[2]);

                Car newCar = new Car(model, fuelAmount, consumption);
                cars.Add(newCar);
            }
        }

        static void Drive(List<Car> cars)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = cmdArgs[1];
                int distance = int.Parse(cmdArgs[2]);

                Car currCar = cars.FirstOrDefault(x => x.Model == model);
                if (currCar == null)
                {
                    continue;
                }

                currCar.DriveADistance(distance);
            }
        }
    }
}
