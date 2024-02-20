namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Bunnies.Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;


    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;

        private Bunny()
        {
            this.Dyes = new HashSet<IDye>();
        }

        protected Bunny(string name, int energy) : this()
        {
            this.Name = name;
            this.Energy = energy;

        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;

            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }

                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public abstract void Work();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int notFinishiedDyesCount = this.Dyes.Count(d => !d.IsFinished());

            sb
                .AppendLine($"Name: {this.Name}")
                .AppendLine($"Energy: {this.Energy}")
                .AppendLine($"Dyes: {notFinishiedDyesCount} not finished");

            return sb.ToString().Trim();
        }

    }
}
