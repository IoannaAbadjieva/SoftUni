namespace Formula1.Models
{
    using System;

    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private const int ModelMinLengthValue = 3;
        private const int MinHorsepowerValue = 900;
        private const int MaxHorsepowerValue = 1050;
        private const double MinEngineDisplacementValue = 1.6;
        private const double MaxEngineDisplacementValue = 2.0;

        private string model;
        private int horsepower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < ModelMinLengthValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this.model = value;
            }

        }

        public int Horsepower
        {
            get => this.horsepower;
            private set
            {
                if (value < MinHorsepowerValue || value > MaxHorsepowerValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDisplacement;
            private set
            {
                if (value < MinEngineDisplacementValue || value > MaxEngineDisplacementValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        => this.EngineDisplacement / this.Horsepower * laps;
    }
}

