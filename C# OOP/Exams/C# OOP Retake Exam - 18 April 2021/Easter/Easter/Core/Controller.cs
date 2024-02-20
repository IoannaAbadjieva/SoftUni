namespace Easter.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Dyes;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs;
    using Easter.Models.Workshops;
    using Easter.Utilities.Messages;
    using Models.Bunnies.Contracts;
    using Models.Eggs.Contracts;
    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };

            this.bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggs.FindByName(eggName);
            var readyBunnies = this.bunnies.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (!readyBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            Workshop workshop = new Workshop();

            while (readyBunnies.Any())
            {
                IBunny bunny = readyBunnies.First();

                workshop.Color(egg, bunny);

                if (!bunny.Dyes.Any())
                {
                    readyBunnies.Remove(bunny);
                }

                if (bunny.Energy == 0)
                {
                    readyBunnies.Remove(bunny);
                    this.bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return string.Format(egg.IsDone() ? OutputMessages.EggIsDone : OutputMessages.EggIsNotDone, eggName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int coloredEggsCount = this.eggs.Models.Count(e => e.IsDone());

            sb.AppendLine($"{coloredEggsCount} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in this.bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
