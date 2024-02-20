using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.baseHealth = health;
            this.Health = health;
            this.baseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth => this.baseHealth;

        public double Health
        {
            get => this.health;

            set
            {
                this.health = value;

                if (this.health > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }

                if (this.health < 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public double BaseArmor => this.baseArmor;

        public double Armor
        {
            get => this.armor;

            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double hitPointsLeft = hitPoints - this.Armor > 0 ? hitPoints - this.Armor : 0;

            this.Armor -= hitPoints;
            this.Health -= hitPointsLeft;
            this.IsAlive = this.Health > 0;

        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
            this.IsAlive = this.Health > 0;
        }

    }
}