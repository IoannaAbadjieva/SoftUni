using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count { get { return cars.Count; } }

        public string AddCar(Car car)
        {

            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber)
        {
            Car searchedCar = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (searchedCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(searchedCar);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registrationNumber in RegistrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
