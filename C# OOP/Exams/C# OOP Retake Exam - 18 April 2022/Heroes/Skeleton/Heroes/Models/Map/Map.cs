namespace Heroes.Models.Map
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Heroes;


    public class Map : IMap
    {

        public string Fight(ICollection<IHero> players)
        {
            HashSet<Knight> knights = new HashSet<Knight>();
            HashSet<Barbarian> barbarians = new HashSet<Barbarian>();

            foreach (var hero in players)
            {
                if (hero.GetType() == typeof(Knight))
                {
                    knights.Add(hero as Knight);
                }
                else if (hero.GetType() == typeof(Barbarian))
                {
                    barbarians.Add(hero as Barbarian);
                }
            }


            while (true)
            {
                int aliveKnights = 0;
                int aliveBarbarians = 0;

                bool allKnightsAreDead = true;
                bool allBarbariansAreDead = true;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        aliveKnights++;
                        allKnightsAreDead = false;

                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        aliveBarbarians++;
                        allBarbariansAreDead = false;

                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                        }
                    }
                }

                if (allBarbariansAreDead)
                {
                    return $"The knights took {knights.Count - aliveKnights} casualties but won the battle.";
                }
                if (allKnightsAreDead)
                {
                    return $"The barbarians took {barbarians.Count - aliveBarbarians} casualties but won the battle.";
                }
            }

        }
    }
}
