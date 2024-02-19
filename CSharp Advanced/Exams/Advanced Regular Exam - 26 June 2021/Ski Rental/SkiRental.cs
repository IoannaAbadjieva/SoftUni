using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public List<Ski> Data => data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return Data.Remove(Data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model));
        }

        public Ski GetNewestSki()
        {
            if (!Data.Any())
            {
                return default;
            }

            return Data.OrderByDescending(s => s.Year).First();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return Data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in Data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
