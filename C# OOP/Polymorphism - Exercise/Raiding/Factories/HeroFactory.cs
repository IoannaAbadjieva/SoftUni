namespace Raiding.Factories
{
    using Contracts;
    using Exceptions;
    using Models.Contracts;
    using Raiding.Models;

    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string type, string name)
        {
            IHero hero;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidHeroTypeException();
            }

            return hero;

        }
    }
}
