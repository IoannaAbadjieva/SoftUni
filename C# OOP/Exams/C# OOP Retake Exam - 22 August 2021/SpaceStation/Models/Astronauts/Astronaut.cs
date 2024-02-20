namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Linq;
    using System.Text;

    using Bags;
    using Bags.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private const double OxygenDecreasementUnits = 10;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        private string name;
        private double oxygen;

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            double oxygenLeft = this.Oxygen - OxygenDecreasementUnits;

            if (oxygenLeft < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen = oxygenLeft;
            }
        }

        public override string ToString()
        {
            string bagItems = this.Bag.Items.Any() ? string.Join(", ", this.Bag.Items) : "none";
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Name: {this.Name}")
                .AppendLine($"Oxygen: {this.Oxygen}")
                .AppendLine($"Bag items: {bagItems}");

            return sb.ToString().Trim();
        }
    }
}
