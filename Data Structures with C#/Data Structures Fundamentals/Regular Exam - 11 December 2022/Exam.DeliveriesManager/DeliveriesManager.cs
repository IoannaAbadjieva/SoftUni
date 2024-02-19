using Exam.DeliveriesManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverers = new Dictionary<string, Deliverer>();
        private Dictionary<string, Package> packages = new Dictionary<string, Package>();

        public DeliveriesManager()
        {
            deliverers = new Dictionary<string, Deliverer>();
            packages = new Dictionary<string, Package>();
        }

        public void AddDeliverer(Deliverer deliverer)
        {
            deliverers[deliverer.Id] = deliverer;
        }

        public void AddPackage(Package package)
        {
            packages[package.Id] = package;
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!deliverers.ContainsKey(deliverer.Id) || !packages.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }

            deliverer.Packages.Add(package);
            package.Deliverer = deliverer;
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverers.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packages.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return deliverers.Values;
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            return deliverers.Values
                .OrderByDescending(d => d.Packages.Count)
                .ThenBy(d => d.Name);
        }

        public IEnumerable<Package> GetPackages()
        {
            return packages.Values;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            return packages.Values
                .OrderByDescending(d => d.Weight)
                .ThenBy(d => d.Receiver);

        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return packages.Values.Where(p => p.Deliverer == null);
        }
    }
}
