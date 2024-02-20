namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Athletes.Contracts;
    using Equipment.Contracts;
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;

        private Gym()
        {
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        protected Gym(string name, int capacity) 
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment { get;  }

        public ICollection<IAthlete> Athletes { get;  }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        => this.Athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            string athletesInfo = this.Athletes.Any() ? string.Join(", ", this.Athletes.Select(a => a.FullName)) : "No athletes";

            sb
                .AppendLine($"{this.Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {athletesInfo}")
                .AppendLine($"Equipment total count: {this.Equipment.Count}")
                .AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }

    }
}
