namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using MilitaryUnits.Contracts;
    using MilitaryUnits;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;
    using Weapons;
    using Weapons.Contracts;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private readonly IRepository<IMilitaryUnit> unitRepository;
        private readonly IRepository<IWeapon> weaponRepository;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.unitRepository = new UnitRepository();
            this.weaponRepository = new WeaponRepository();
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => Math.Round(GetMilitaryPower(), 3);

        public IReadOnlyCollection<IMilitaryUnit> Army => this.unitRepository.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weaponRepository.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weaponRepository.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string forces = this.Army.Count > 0 ? string.Join(", ", this.Army.Select(u => u.GetType().Name)) : "No units";
            string equipment = this.Weapons.Count > 0 ? string.Join(", ", this.Weapons.Select(w => w.GetType().Name)) : "No weapons";

            sb
                .AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {forces}")
                .AppendLine($"--Combat equipment: {equipment}")
                .AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();

        }

        private double GetMilitaryPower()
        {
            double totalAmount = 0;

            totalAmount += this.unitRepository.Models.Sum(u => u.EnduranceLevel);
            totalAmount += this.weaponRepository.Models.Sum(w => w.DestructionLevel);

            if (unitRepository.Models.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount += 0.30 * totalAmount;
            }

            if (weaponRepository.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount += 0.45 * totalAmount;
            }

            return totalAmount;
        }
    }
}
