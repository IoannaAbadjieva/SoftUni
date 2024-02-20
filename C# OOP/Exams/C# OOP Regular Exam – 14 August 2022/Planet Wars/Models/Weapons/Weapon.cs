namespace PlanetWars.Models.Weapons
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Weapon : IWeapon
    {
        private const int MinDestructionLevel = 1;
        private const int MaxDestructionLevel = 10;

        private double price;
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price
        {
            get => this.price;

            private set
            {
                this.price = value;
            }
        }

        public int DestructionLevel
        {
            get { return this.destructionLevel; }

            private set
            {
                if (value < MinDestructionLevel)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }

                if (value > MaxDestructionLevel)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                this.destructionLevel = value;
            }
        }
    }
}
