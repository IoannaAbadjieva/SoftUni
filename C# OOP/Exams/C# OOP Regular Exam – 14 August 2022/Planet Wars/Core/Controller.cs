
namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.MilitaryUnits.Contracts;
    using Models.MilitaryUnits;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Models.Weapons.Contracts;
    using Models.Weapons;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;


    public class Controller : IController
    {
        private const double SpecializeForcesCost = 1.25;

        private readonly IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = this.planets.Models.FirstOrDefault(planet => planet.Name == name);

            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);
            this.planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.Models.FirstOrDefault(planet => planet.Name == planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
                        
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                nameof(StormTroopers) => new StormTroopers(),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.Models.FirstOrDefault(planet => planet.Name == planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))
            };

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.Models.FirstOrDefault(planet => planet.Name == planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(SpecializeForcesCost);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = this.planets.FindByName(planetOne);
            IPlanet secondPlanet = this.planets.FindByName(planetTwo);
            IPlanet winningPlanet;
            IPlanet losingPlanet;

            double powerDiff = firstPlanet.MilitaryPower - secondPlanet.MilitaryPower;


            if (powerDiff > 0)
            {
                winningPlanet = firstPlanet;
                losingPlanet = secondPlanet;
            }
            else if (powerDiff < 0)
            {
                winningPlanet = secondPlanet;
                losingPlanet = firstPlanet;
            }
            else
            {
                if (firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                && !secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winningPlanet = firstPlanet;
                    losingPlanet = secondPlanet;
                }
                else if (!firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                && secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winningPlanet = secondPlanet;
                    losingPlanet = firstPlanet;
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }

            winningPlanet.Spend(winningPlanet.Budget / 2);
            winningPlanet.Profit(losingPlanet.Budget / 2);
            winningPlanet.Profit(losingPlanet.Army.Sum(u => u.Cost) + losingPlanet.Weapons.Sum(w => w.Price));

           this.planets.RemoveItem(losingPlanet.Name);

            return string.Format(OutputMessages.WinnigTheWar, winningPlanet.Name, losingPlanet.Name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            var orderedPlanets = this.planets.Models
                .OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name);

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }


    }
}
