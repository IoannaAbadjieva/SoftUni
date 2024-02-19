
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.PackageManagerLite
{
    public class PackageManager : IPackageManager
    {
        private Dictionary<string, Package> packages;
        private Dictionary<string, Package> packagesByName;
        private Dictionary<string, HashSet<Package>> packageDependencies;
        private Dictionary<string, HashSet<Package>> packageDependents;



        public PackageManager()
        {
            this.packages = new Dictionary<string, Package>();
            this.packagesByName = new Dictionary<string, Package>();
            this.packageDependencies = new Dictionary<string, HashSet<Package>>();
            this.packageDependents = new Dictionary<string, HashSet<Package>>();
        }

        public void RegisterPackage(Package package)
        {
            if (this.packages.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }

            if (this.packagesByName.ContainsKey(package.Name))
            {
                var existingPackage = this.packagesByName[package.Name];

                if (existingPackage.Version == package.Version)
                {
                    throw new ArgumentException();
                }

                if (existingPackage.ReleaseDate < package.ReleaseDate)
                {
                    this.packagesByName[package.Name] = package;
                }
            }
            else
            {
                this.packagesByName.Add(package.Name, package);
            }

            this.packages.Add(package.Id, package);
            this.packageDependents.Add(package.Id, new HashSet<Package>());
            this.packageDependencies.Add(package.Id, new HashSet<Package>());

        }

        public void RemovePackage(string packageId)
        {

            if (!this.packages.ContainsKey(packageId))
            {
                throw new ArgumentException();
            }

            var package = this.packages[packageId];

            foreach (Package dependency in this.packageDependencies[packageId])
            {
                this.packageDependents[dependency.Id].Remove(package);
            }


            foreach (Package depentent in this.packageDependents[packageId])
            {
                this.packageDependencies[depentent.Id].Remove(package);
            }

            if (this.packagesByName.ContainsKey(package.Name) &&
                this.packagesByName[package.Name].Id == packageId)
            {
                this.packagesByName.Remove(package.Name);
            }

            this.packages.Remove(packageId);
        }

        public void AddDependency(string packageId, string dependencyId)
        {

            if (!this.packages.ContainsKey(packageId) || !this.packages.ContainsKey(dependencyId))
            {
                throw new ArgumentException();
            }

            var package = this.packages[packageId];
            var dependency = this.packages[dependencyId];

            this.packageDependencies[packageId].Add(dependency);
            this.packageDependents[dependencyId].Add(package);
        }

        public bool Contains(Package package)
        {
            return this.packages.ContainsKey(package.Id);
        }

        public int Count()
        {
            return this.packages.Count;
        }

        public IEnumerable<Package> GetDependants(Package package)
        {
            return this.packageDependents[package.Id];
        }

        public IEnumerable<Package> GetIndependentPackages()
        {
            return this.packages.Values
                .Where(p => this.packageDependencies[p.Id].Count == 0)
                .OrderByDescending(p => p.ReleaseDate)
                .ThenBy(p => p.Version);
        }

        public IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion()
        {
            return this.packagesByName.Values
             .OrderByDescending(p => p.ReleaseDate)
             .ThenBy(p => p.Version);
        }

    }
}
