namespace PlanetWars.Models.MilitaryUnits
{
    using System;

    using Contracts;
    using PlanetWars.Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int MaxEndurance = 20;

        private double cost;
        private int enduranceLevel = 1;

        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }

        public double Cost
        {
            get => this.cost;

            private set
            {
                this.cost = value;
            }
        }

        public int EnduranceLevel => this.enduranceLevel;

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel == MaxEndurance)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }

            this.enduranceLevel++;
        }
    }
}
