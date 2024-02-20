namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Cars;
    using Models.Cars.Contracts;
    using Models.Maps;
    using Models.Maps.Contracts;
    using Models.Racers;
    using Models.Racers.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),
                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException(ExceptionMessages.InvalidCarType)
            };

            this.cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, car),
                nameof(StreetRacer) => new StreetRacer(username, car),
                _ => throw new ArgumentException(ExceptionMessages.InvalidRacerType)
            };

            this.racers.Add(racer);
            this.cars.Remove(car);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var orderedRacers = this.racers.Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username);

            foreach (var racer in orderedRacers)
            {
                sb.AppendLine(racer.ToString());

            }

            return sb.ToString().Trim();
        }
    }
}
