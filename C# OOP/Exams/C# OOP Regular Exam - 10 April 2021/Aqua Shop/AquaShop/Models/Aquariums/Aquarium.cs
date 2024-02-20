namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        private Aquarium()
        {
            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();
        }

        protected Aquarium(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
         => this.Fish.Remove(fish);

        public void AddDecoration(IDecoration decoration)
        {
           this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {(this.Fish.Any() ? string.Join(", ", this.Fish.Select(f => f.Name)) : "none")}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }

    }
}
