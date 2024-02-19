using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        private string material;

        private int capacity;

        public Net(string material, int capacity)
        {
            fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public List<Fish> Fish { get { return fish; } }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count { get { return Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";

        }

        public bool ReleaseFish(double weight)
        {
            return Fish.Remove(Fish.FirstOrDefault(f => f.Weight == weight));
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            double maxLenght = Fish.Max(f => f.Length);
            return Fish.FirstOrDefault(f => f.Length == maxLenght);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (Fish fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
