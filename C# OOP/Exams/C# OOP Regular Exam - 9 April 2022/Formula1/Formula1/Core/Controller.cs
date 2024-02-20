namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities;

    public class Controller : IController
    {
        private const int ParticipantsMinCount = 3;

        private readonly IRepository<IFormulaOneCar> carRepository;
        private readonly IRepository<IPilot> pilotRepository;
        private readonly IRepository<IRace> raceRepository;

        public Controller()
        {
            this.carRepository = new FormulaOneCarRepository();
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this.carRepository.FindByName(model);

            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            car = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type))
            };

            this.carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = this.carRepository.FindByName(carModel);

            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < ParticipantsMinCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> winners = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .ToList();

            race.TookPlace = true;
            winners[0].WinRace();

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Pilot {winners[0].FullName} wins the {race.RaceName} race.")
                .AppendLine($"Pilot {winners[1].FullName} is second in the {race.RaceName} race.")
                .AppendLine($"Pilot {winners[2].FullName} is third in the {race.RaceName} race.");

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models.Where(r => r.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
