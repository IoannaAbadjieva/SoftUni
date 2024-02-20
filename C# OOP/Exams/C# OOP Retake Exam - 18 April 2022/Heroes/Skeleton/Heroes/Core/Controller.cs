namespace Heroes.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Models.Contracts;
    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {

        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heroes.FindByName(name);

            if (hero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };


            this.heroes.Add(hero);
            string title = type == nameof(Knight) ? "Sir" : "Barbarian";
            return $"Successfully added {title} {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = this.weapons.FindByName(name);

            if (weapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _ => throw new InvalidOperationException("Invalid weapon type.")
            };

            this.weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";

        }

        public string StartBattle()
        {
            Map map = new Map();
            HashSet<IHero> heroesReadyTobattle = this.heroes
                .Models
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToHashSet();

            return map.Fight(heroesReadyTobattle);
        }

        public string HeroReport()
        {
           StringBuilder sb = new StringBuilder();

            var orderedHeroes = this.heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name)
                .ToList();

            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
