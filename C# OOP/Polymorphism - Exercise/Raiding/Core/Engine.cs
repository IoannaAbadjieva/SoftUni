namespace Raiding.Core
{

    using System.Collections.Generic;

    using Contracts;
    using Raiding.Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;
    using System.Linq;
    using Raiding.Exceptions;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IHeroFactory heroFactory;

        private ICollection<IHero> heroes;

        private Engine()
        {
            this.heroes = new HashSet<IHero>();
        }

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }


        public void Run()
        {
            int heroesCount = int.Parse(this.reader.ReadLine());

            string name = this.reader.ReadLine();

            while (!int.TryParse(name, out int result))
            {
                try
                {
                    string type = this.reader.ReadLine();
                    if (this.heroes.Count < heroesCount)
                    {
                        this.heroes.Add(CreateNewHero(name, type));

                    }
                    
                }
                catch (InvalidHeroTypeException ihte)
                {

                    this.writer.WriteLine(ihte.Message);
                }
                catch
                {
                    throw;
                }

                name = this.reader.ReadLine();
            }

            int bossPower = int.Parse(name);
            int heroesTotalPower = this.heroes.Sum(h => h.Power);

            PrintHeroes();
            if (bossPower > heroesTotalPower)
            {
                this.writer.WriteLine("Defeat...");
            }
            else
            {
                this.writer.WriteLine("Victory!");
            }
        }

        private IHero CreateNewHero(string name, string type)
        {
            IHero hero = heroFactory.CreateHero(type, name);
            return hero;
        }

        private void PrintHeroes()
        {
            foreach (IHero hero in this.heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
            }
        }

    }
}
