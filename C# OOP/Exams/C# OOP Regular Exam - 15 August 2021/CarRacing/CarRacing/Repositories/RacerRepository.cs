namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Racers.Contracts;
    using Utilities.Messages;
  

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> racers;

        public RacerRepository()
        {
            this.racers = new HashSet<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
            => (IReadOnlyCollection<IRacer>)this.racers;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.racers.Add(model);
        }

        public IRacer FindBy(string property)
        => this.racers.FirstOrDefault(r => r.Username == property);

        public bool Remove(IRacer model)
        =>this.racers.Remove(model);
    }
}
