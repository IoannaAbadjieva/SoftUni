using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int ParticipantsMinCount = 3;

        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = this.carRepository.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.carRepository.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            this.carRepository.Remove(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);

        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {

            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < ParticipantsMinCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,
                    raceName, ParticipantsMinCount));
            }

            IDriver[] winners = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            winners[0].WinRace();
            this.raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, raceName));

            return sb.ToString().Trim();
        }
    }
}
