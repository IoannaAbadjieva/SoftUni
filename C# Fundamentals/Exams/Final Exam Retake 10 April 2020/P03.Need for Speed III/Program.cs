namespace P03.Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxMileage = 100000;

            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                cars[model] = new Car(model, mileage, fuel);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string model = cmdArgs[1];

                if (!cars.ContainsKey(model))
                {
                    continue;
                }

                if (cmdType == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    int neededfuel = int.Parse(cmdArgs[3]);

                    cars[model].Drive(distance, neededfuel);
                    if (cars[model].Mileage >= MaxMileage)
                    {
                        Console.WriteLine($"Time to sell the {model}!");
                        cars.Remove(model);
                    }
                }
                else if (cmdType == "Refuel")
                {
                    int fuelToFill = int.Parse(cmdArgs[2]);
                    cars[model].Refuel(fuelToFill);
                }
                else if (cmdType == "Revert")
                {
                    int kilometers = int.Parse(cmdArgs[2]);
                    cars[model].Revert(kilometers);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
    class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Model { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public void Drive(int distance, int neededFuel)
        {
            if (neededFuel <= Fuel)
            {
                Fuel -= neededFuel;
                Mileage += distance;
                Console.WriteLine($"{Model} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
        }
        public void Refuel(int fuelToFill)
        {
            const int TankVolume = 75;

            int fuellToFit = TankVolume - Fuel;
            int filledFuel = fuelToFill;

            if (fuelToFill > fuellToFit)
            {
                filledFuel = fuellToFit;
            }
            Fuel += filledFuel;
            Console.WriteLine($"{Model} refueled with {filledFuel} liters");
        }

        public void Revert(int kilometers)
        {
            const int MinMileage = 10000;

            Mileage -= kilometers;

            if (Mileage < MinMileage)
            {
                Mileage = MinMileage;
            }
            else
            {
                Console.WriteLine($"{Model} mileage decreased by {kilometers} kilometers");
            }
        }

        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}


