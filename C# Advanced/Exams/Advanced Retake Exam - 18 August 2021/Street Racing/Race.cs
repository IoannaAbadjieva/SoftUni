using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private Dictionary<string, Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            participants = new Dictionary<string, Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public Dictionary<string, Car> Participants => participants;

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => participants.Count;

        public void Add(Car car)
        {
            if (!participants.ContainsKey(car.LicensePlate)
                && Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return participants.Remove(licensePlate);
        }

        public Car FindParticipant(string licensePlate)
        {
            if (!participants.ContainsKey(licensePlate))
            {
                return default;
            }

            return participants[licensePlate];
        }

        public Car GetMostPowerfulCar()
        {
            if (!participants.Any())
            {
                return default;
            }

            return participants.Values.OrderByDescending(c => c.HorsePower).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in participants)
            {
                sb.AppendLine(car.Value.ToString());
            }

            return sb.ToString();
        }

    }
}
