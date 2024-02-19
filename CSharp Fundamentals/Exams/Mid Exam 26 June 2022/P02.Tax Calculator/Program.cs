using System;
using System.Linq;

namespace P02.Tax_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = Console.ReadLine()
                .Split(">>", StringSplitOptions.RemoveEmptyEntries);

            string[] vehicleTypes = { "family", "heavyDuty", "sports" };

            double totalTaxes = 0;

            for (int index = 0; index < cars.Length; index++)
            {
                string car = cars[index];

                string[] currentVehicle = car
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vehicleType = currentVehicle[0];
                int years = int.Parse(currentVehicle[1]);
                int kmTraveled = int.Parse(currentVehicle[2]);

                if (!vehicleTypes.Contains(vehicleType))
                {
                    Console.WriteLine("Invalid car type.");
                    continue;
                }
                double currentVehicleTax = CalculateCarTaxes(vehicleType, years, kmTraveled);
                Console.WriteLine($"A {vehicleType} car will pay {currentVehicleTax:f2} euros in taxes.");
                totalTaxes += currentVehicleTax;
            }
            Console.WriteLine($"The National Revenue Agency will collect {totalTaxes:f2} euros in taxes.");
        }

        static double CalculateCarTaxes(string vehicleType, int years, int kmTraveled)
        {
            double tax = 0;
            if (vehicleType == "family")
            {
                tax += 50;
                tax -= years * 5;
                tax += (kmTraveled / 3000) * 12;
            }
            else if (vehicleType == "heavyDuty")
            {
                tax += 80;
                tax -= years * 8;
                tax += (kmTraveled / 9000) * 14;
            }
            else
            {
                tax += 100;
                tax -= years * 9;
                tax += (kmTraveled / 2000) * 18;
            }

            return tax;
        }
    }
}
