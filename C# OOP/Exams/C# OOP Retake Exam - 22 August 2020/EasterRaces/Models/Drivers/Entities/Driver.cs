using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{

    public class Driver : IDriver
    {
        private const int NameMinLenght = 5;

        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NameMinLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, NameMinLenght));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate =>this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
