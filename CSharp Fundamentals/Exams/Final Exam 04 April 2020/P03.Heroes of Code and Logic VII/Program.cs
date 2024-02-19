using System.Text;

namespace P03.Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = heroInfo[0];
                int hitPoints = int.Parse(heroInfo[1]);
                int manaPoints = int.Parse(heroInfo[2]);

                Hero newHero = new Hero(name, hitPoints, manaPoints);
                heroes.Add(newHero);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string name = cmdArgs[1];

                Hero hero = heroes.Find(x => x.Name == name);
                if (hero == null)
                {
                    continue;
                }

                if (cmdType == "CastSpell")
                {
                    int manaPoints = int.Parse(cmdArgs[2]);
                    string spell = cmdArgs[3];

                    hero.CastSpell(manaPoints, spell);
                }
                else if (cmdType == "TakeDamage")
                {
                    int damage = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];

                    hero.TakeDamage(damage, attacker);

                    if (!hero.IsHitPointsLeft())
                    {
                        heroes.Remove(hero);
                    }
                }
                else if (cmdType == "Recharge")
                {
                    int amount = int.Parse(cmdArgs[2]);
                    hero.Recharge(amount);
                }
                else if (cmdType == "Heal")
                {
                    int amount = int.Parse(cmdArgs[2]);
                    hero.Heal(amount);
                }
            }
            PrintHeroes(heroes);
        }

        private static void PrintHeroes(List<Hero> heroes)
        {
            heroes.ForEach(Console.WriteLine);
        }
    }

    class Hero
    {
        public Hero(string name, int hitPoints, int manaPoints)
        {
            Name = name;
            HitPoints = hitPoints;
            ManaPoints = manaPoints;
        }

        public string Name { get; set; }

        public int HitPoints { get; set; }

        public int ManaPoints { get; set; }

        public void CastSpell(int manaPoints, string spell)
        {
            if (ManaPoints >= manaPoints)
            {
                ManaPoints -= manaPoints;
                Console.WriteLine($"{Name} has successfully cast {spell} and now has {ManaPoints} MP!");
                return;
            }
            Console.WriteLine($"{Name} does not have enough MP to cast {spell}!");
        }

        public void TakeDamage(int damage, string attacker)
        {
            HitPoints -= damage;
            if (HitPoints <= 0)
            {
                Console.WriteLine($"{Name} has been killed by {attacker}!");
                return;
            }
            Console.WriteLine($"{Name} was hit for {damage} HP by {attacker} and now has {HitPoints} HP left!");
        }

        public bool IsHitPointsLeft()
        {
            return HitPoints > 0;
        }

        public void Recharge(int amount)
        {
            const int ManaPointsMaxValue = 200;
            int mana = ManaPoints;

            ManaPoints += amount;

            if (ManaPoints > ManaPointsMaxValue)
            {
                ManaPoints = ManaPointsMaxValue;
            }

            Console.WriteLine($"{Name} recharged for {ManaPoints - mana} MP!");
        }

        public void Heal(int amount)
        {
            const int HitPointsMaxValue = 100;
            int hit = HitPoints;

            HitPoints += amount;

            if (HitPoints > HitPointsMaxValue)
            {
                HitPoints = HitPointsMaxValue;
            }

            Console.WriteLine($"{Name} healed for {HitPoints - hit} HP!");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name}");
            sb.AppendLine($" HP: {HitPoints}");
            sb.Append($" MP: {ManaPoints}");

            return sb.ToString();
        }
    }
}
