using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int NameMinLenght = 4;

        private string model;
        private int horsepower;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NameMinLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, NameMinLenght));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsepower;

            private set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsepower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        => this.CubicCentimeters / this.HorsePower * laps;
    }
}
