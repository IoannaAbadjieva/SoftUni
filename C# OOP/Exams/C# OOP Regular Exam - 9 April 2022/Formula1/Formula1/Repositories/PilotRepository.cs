namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;


    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
            => (IReadOnlyCollection<IPilot>)this.pilots;

        public void Add(IPilot model)
        {
            this.pilots.Add(model);
        }

        public IPilot FindByName(string name)
        => this.pilots.FirstOrDefault(p => p.FullName == name);

        public bool Remove(IPilot model)
        => this.pilots.Remove(model);
    }
}
