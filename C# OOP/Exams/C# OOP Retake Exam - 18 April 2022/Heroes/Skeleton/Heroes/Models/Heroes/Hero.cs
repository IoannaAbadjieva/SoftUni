namespace Heroes.Models.Heroes
{
    using System;
    using System.Text;

    using Contracts;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
            }
        }

        public bool IsAlive => this.health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int armourLeft = this.Armour - points;

            if (armourLeft >= 0)
            {
                this.Armour = armourLeft;
            }
            else
            {
                this.Armour = 0;
                int healthLeft = this.Health + armourLeft;

                if (healthLeft >= 0)
                {
                    this.Health = healthLeft;
                }
                else
                {
                    this.Health = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string armed = this.Weapon != null ? this.Weapon.Name : "Unarmed";

            sb
                .AppendLine($"{this.GetType().Name}: {this.Name}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armour: {this.Armour}")
                .AppendLine($"--Weapon: {armed}");

            return sb.ToString().Trim();
        }
    }
}
