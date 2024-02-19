using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        private string name;

        private int capacity;

        private double landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }


        public List<Drone> Drones { get { return drones; } }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public double LandingStrip
        {
            get { return landingStrip; }
            set { landingStrip = value; }
        }

        public int Count { get { return drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (Capacity == Drones.Count)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            return Drones.Remove(Drones.FirstOrDefault(d => d.Name == name));
        }

        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(d => d.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDronesByRange = Drones.FindAll(d => d.Range >= range);
            foreach (var drone in flownDronesByRange)
            {
                drone.Available = false;
            }
            return flownDronesByRange;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");

            foreach (Drone drone in Drones.Where(d => d.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
