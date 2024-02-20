namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
   
    using Contracts;
    using Models.Contracts;
  

    public class RaceRepository:IRepository<IRace>
    {
        private readonly ICollection<IRace> races;

        public RaceRepository()
        {
            this.races = new HashSet<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
            =>(IReadOnlyCollection<IRace>) this.races;

        public void Add(IRace model)
        {
           this.races.Add(model);
        }

        public IRace FindByName(string name)
        =>this.races.FirstOrDefault(r => r.RaceName== name);

        public bool Remove(IRace model)
        =>this.races.Remove(model);
    }
}
