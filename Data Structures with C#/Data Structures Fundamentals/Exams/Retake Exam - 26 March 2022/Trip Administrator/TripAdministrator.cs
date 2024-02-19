using System;
using System.Collections.Generic;
using System.Linq;

namespace TripAdministrations
{
    public class TripAdministrator : ITripAdministrator
    {
        private Dictionary<string, Company> companiesByName = new Dictionary<string, Company>();
        private Dictionary<string, Trip> tripsById = new Dictionary<string, Trip>();
        private Dictionary<string, HashSet<Trip>> companyTrips = new Dictionary<string, HashSet<Trip>>();

        public TripAdministrator()
        {
            this.companiesByName = new Dictionary<string, Company>();
            this.tripsById = new Dictionary<string, Trip>();
            this.companyTrips = new Dictionary<string, HashSet<Trip>>();
        }

        public void AddCompany(Company c)
        {
            if (this.companiesByName.ContainsKey(c.Name))
            {
                throw new ArgumentException();
            }

            this.companiesByName.Add(c.Name, c);
            this.companyTrips.Add(c.Name, new HashSet<Trip>());
        }

        public void AddTrip(Company c, Trip t)
        {
            if (!this.companiesByName.ContainsKey(c.Name))
            {
                throw new ArgumentException();
            }

            if (this.companiesByName[c.Name].CurrentTrips == this.companiesByName[c.Name].TripOrganizationLimit)
            {
                throw new ArgumentException();
            }

            this.tripsById.Add(t.Id, t);
            this.companyTrips[c.Name].Add(t);
            this.companiesByName[c.Name].CurrentTrips++;
        }

        public bool Exist(Company c)
        {
            return this.companiesByName.ContainsKey(c.Name);
        }

        public bool Exist(Trip t)
        {
            return this.tripsById.ContainsKey(t.Id);
        }

        public void RemoveCompany(Company c)
        {
            if (!this.companiesByName.ContainsKey(c.Name))
            {
                throw new ArgumentException();
            }

            foreach (var trip in this.companyTrips[c.Name])
            {
                this.tripsById.Remove(trip.Id);
            }

            this.companiesByName.Remove(c.Name);
            this.companyTrips.Remove(c.Name);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return this.companiesByName.Values;
        }

        public IEnumerable<Trip> GetTrips()
        {
            return this.tripsById.Values;
        }

        public void ExecuteTrip(Company c, Trip t)
        {
            if (!this.companiesByName.ContainsKey(c.Name) || !this.tripsById.ContainsKey(t.Id))
            {
                throw new ArgumentException();
            }

            if (!this.companyTrips[c.Name].Contains(t))
            {
                throw new ArgumentException();
            }

            this.tripsById.Remove(t.Id);
            this.companyTrips[c.Name].Remove(t);
        }

        public IEnumerable<Company> GetCompaniesWithMoreThatNTrips(int n)
        {
            return this.companiesByName.Values
                 .Where(c => companyTrips[c.Name].Count > n);
        }

        public IEnumerable<Trip> GetTripsWithTransportationType(Transportation t)
        {
            return this.tripsById.Values
                .Where(trip => trip.Transportation == t);
        }

        public IEnumerable<Trip> GetAllTripsInPriceRange(int lo, int hi)
        {
            return this.tripsById.Values
                .Where(t => t.Price >= lo && t.Price <= hi);
        }
    }
}
