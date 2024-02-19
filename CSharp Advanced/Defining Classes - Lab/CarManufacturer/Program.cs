using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> carsList = new List<Car>();

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "No more tires")
                {
                    break;
                }

                string[] tiresInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(tiresInfo[0]),double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]),double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]),double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]),double.Parse(tiresInfo[7])),
                };

                tiresList.Add(tires);
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Engines done")
                {
                    break;
                }

                string[] enginesInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(enginesInfo[0]), double.Parse(enginesInfo[1]));
                enginesList.Add(engine);
            }



            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Show special")
                {
                    break;
                }

                string[] carInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, enginesList[engineIndex], tiresList[tiresIndex]);
                carsList.Add(car);
            }

            const int MinYear = 2017;
            const int MinHorsePower = 330;
            const int MinTiresPressure = 9;
            const int MaxTiresPressure = 10;
            const double DriveDistance = 20;

            List<Car> specialCars = carsList
                .Where(c => c.Year >= MinYear && c.Engine.HorsePower > MinHorsePower && c.Tires.Sum(t => t.Pressure) > MinTiresPressure && c.Tires.Sum(t => t.Pressure) < MaxTiresPressure)
                .ToList();


            foreach (var car in specialCars)
            {
                car.Drive(DriveDistance / 100);
                Console.WriteLine(car);
            }
        }
    }
}
