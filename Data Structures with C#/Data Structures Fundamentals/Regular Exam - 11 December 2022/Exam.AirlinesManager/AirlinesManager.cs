using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> airlines;
        private Dictionary<string, Flight> flights;

        public AirlinesManager()
        {
            airlines = new Dictionary<string, Airline>();
            flights = new Dictionary<string, Flight>();
        }
        public void AddAirline(Airline airline)
        {
            airlines[airline.Id] = airline;
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            flights[flight.Id] = flight;
            airlines[airline.Id].Flights.Add(flight);
        }

        public bool Contains(Airline airline)
        {
            return airlines.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return flights.ContainsKey(flight.Id);
        }

        public void DeleteAirline(Airline airline)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            foreach (var flight in airlines[airline.Id].Flights)
            {
                flights.Remove(flight.Id);
            }

            airlines.Remove(airline.Id);

        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            return airlines.Values
                .OrderByDescending(a => a.Rating)
                .ThenByDescending(a => a.Flights.Count)
                .ThenBy(a => a.Name);
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            return airlines.Values
                .Where(a => a.Flights
                .Any(f => f.Origin == origin && f.Destination == destination && !f.IsCompleted));
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return flights.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return flights.Values.Where(f => f.IsCompleted);
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            return flights.Values
                .OrderBy(f => f.IsCompleted)
                .ThenBy(f => f.Number);
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            if (!flights.ContainsKey(flight.Id))
            {
                throw new ArgumentException();
            }


            flights[flight.Id].IsCompleted = true;
            return flights[flight.Id];
        }
    }
}
