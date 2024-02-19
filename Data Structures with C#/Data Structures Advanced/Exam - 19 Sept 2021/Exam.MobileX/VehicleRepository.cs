using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<string, Vehicle> allVehicles = new Dictionary<string, Vehicle>();
        private Dictionary<string, HashSet<Vehicle>> sellers = new Dictionary<string, HashSet<Vehicle>>();

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (!sellers.ContainsKey(sellerName))
            {
                sellers.Add(sellerName, new HashSet<Vehicle>());
            }

            vehicle.Seller = sellerName;
            allVehicles.Add(vehicle.Id, vehicle);
            sellers[sellerName].Add(vehicle);
        }

        public bool Contains(Vehicle vehicle)
        {
            return allVehicles.ContainsKey(vehicle.Id);
        }

        public int Count => this.allVehicles.Count;

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            return allVehicles.Values
                .Where(v => keywords.Contains(v.Brand) ||
                            keywords.Contains(v.Model) ||
                            keywords.Contains(v.Location) ||
                            keywords.Contains(v.Color))
                .OrderByDescending(v => v.IsVIP)
                .ThenBy(v => v.Price);
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!sellers.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            return sellers[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            return allVehicles.Values
                .Where(v => v.Price >= lowerBound && v.Price <= upperBound)
                .OrderByDescending(v => v.Horsepower);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (Count == 0)
            {
                throw new ArgumentException();
            }

            var result = new Dictionary<string, SortedSet<Vehicle>>();

            foreach (var vehicle in allVehicles.Values)
            {
                if (!result.ContainsKey(vehicle.Brand))
                {
                    result.Add(vehicle.Brand, new SortedSet<Vehicle>());
                }

                result[vehicle.Brand].Add(vehicle);
            }

            return result.ToDictionary(x => x.Key, x => x.Value.ToList());
        }

        public void RemoveVehicle(string vehicleId)
        {
            if (!allVehicles.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }

            var vehicle = allVehicles[vehicleId];
            allVehicles.Remove(vehicleId);
            sellers[vehicle.Seller].Remove(vehicle);
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            return allVehicles.Values
              .OrderByDescending(v => v.Horsepower)
              .ThenBy(v => v.Price)
              .ThenBy(v => v.Seller);
        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!sellers.ContainsKey(sellerName) || sellers[sellerName].Count == 0)
            {
                throw new ArgumentException();
            }

            var vehicle = sellers[sellerName]
                .OrderBy(v => v.Price)
                .First();

            allVehicles.Remove(vehicle.Id);
            sellers[sellerName].Remove(vehicle);

            return vehicle;
        }





    }
}
