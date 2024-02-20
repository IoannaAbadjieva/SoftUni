using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;


namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int NameMinLenght = 5;
        private const int MinLapsCount = 1;

        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        private Race()
        {
            this.drivers = new List<IDriver>();
        }

        public Race(string name, int laps)
            : this()
        {
            this.Name = name;
            this.Laps = laps;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NameMinLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value,NameMinLenght));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < MinLapsCount)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLapsCount));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
            => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
