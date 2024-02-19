using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string model = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                int distance = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);

                Car searchedCar = cars.Find(x => x.Model == model);
                if (searchedCar != null)
                {
                    searchedCar.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
