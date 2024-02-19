using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine newEngine = SetNewEngine(engineInfo);
                engines.Add(newEngine);
            }

            List<Car>cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[]carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car newCar = SetNewCar(carInfo, engines);
                cars.Add(newCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        static Engine SetNewEngine(string[] engineInfo)
        {
            Engine newEngine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));

            if (engineInfo.Length > 2)
            {
                if (int.TryParse(engineInfo[2], out int displacement))
                {
                    newEngine.Displacement = displacement;
                }
                else
                {
                    newEngine.Efficiency = engineInfo[2];
                }
            }

            if (engineInfo.Length > 3)
            {
                newEngine.Efficiency = engineInfo[3];
            }

            return newEngine;
        }

        static Car SetNewCar(string[] carInfo, List<Engine> engines)
        {
            string model = carInfo[0];
            Engine engine = engines.Find(e => e.Model == carInfo[1]);

            Car newCar = new Car(model, engine);


            if (carInfo.Length > 2)
            {
                if (int.TryParse(carInfo[2], out int weight))
                {
                    newCar.Weight = weight;
                }
                else
                {
                    newCar.Color = carInfo[2];
                }
            }

            if (carInfo.Length > 3)
            {
                newCar.Color = carInfo[3];
            }
            return newCar;
        }
    }
}
