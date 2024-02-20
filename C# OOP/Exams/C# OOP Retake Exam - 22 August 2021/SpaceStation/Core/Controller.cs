namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Planets.Contracts;
    using Models.Mission;
    using Models.Mission.Contracts;
    using Models.Planets;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private ICollection<string> exploredPlanets;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.exploredPlanets = new HashSet<string>();
        }


        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = type switch
            {
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                nameof(Meteorologist) => new Meteorologist(astronautName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType)
            };

            this.astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planetRepository.FindByName(planetName);

            List<IAstronaut> astronautsOnMission = this.astronautRepository.Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (!astronautsOnMission.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            int initialAstronautsCount = astronautsOnMission.Count();

            IMission mission = new Mission();
            mission.Explore(planet, astronautsOnMission);
            this.exploredPlanets.Add(planetName);
            int astronautsCount = astronautsOnMission.Where(a => a.CanBreath).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, initialAstronautsCount - astronautsCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{exploredPlanets.Count} planets were explored!")
                .AppendLine($"Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
