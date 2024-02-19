using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private Dictionary<string, Bus> busesById = new Dictionary<string, Bus>();
        private Dictionary<string, Passenger> passengersById = new Dictionary<string, Passenger>();
        private Dictionary<string, HashSet<Passenger>> passengersOnBus = new Dictionary<string, HashSet<Passenger>>();

        public PublicTransportRepository()
        {
            this.busesById = new Dictionary<string, Bus>();
            this.passengersById = new Dictionary<string, Passenger>();
            this.passengersOnBus = new Dictionary<string, HashSet<Passenger>>();
        }

        public void RegisterPassenger(Passenger passenger)
        {
            this.passengersById.Add(passenger.Id, passenger);
        }

        public void AddBus(Bus bus)
        {
            this.busesById.Add(bus.Id, bus);
            this.passengersOnBus.Add(bus.Id,new HashSet<Passenger>());
        }

        public bool Contains(Passenger passenger)
        {
            return this.passengersById.ContainsKey(passenger.Id);
        }

        public bool Contains(Bus bus)
        {
            return this.busesById.ContainsKey(bus.Id);
        }

        public IEnumerable<Bus> GetBuses()
        {
            return this.busesById.Values;
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!this.passengersById.ContainsKey(passenger.Id))
            {
                throw new ArgumentException();
            }
            
            if (!this.busesById.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            if (this.passengersOnBus[bus.Id].Count == this.busesById[bus.Id].Capacity)
            {
                throw new ArgumentException();
            }

            this.passengersOnBus[bus.Id].Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!this.passengersById.ContainsKey(passenger.Id))
            {
                throw new ArgumentException();
            }

            if (!this.busesById.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            if (!this.passengersOnBus[bus.Id].Contains(passenger))
            {
                throw new ArgumentException();
            }

            this.passengersOnBus[bus.Id].Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            return this.passengersOnBus[bus.Id];
        }

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            return this.busesById.Values
                .OrderBy(b => passengersOnBus[b.Id].Count);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
        {
            return this.busesById.va
        }
    }
}