using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        => (IReadOnlyCollection<IRace>)this.races;

        public IRace GetByName(string name)
        => this.races.FirstOrDefault(r => r.Name == name);

        public bool Remove(IRace model)
        =>this.races.Remove(model);
    }
}
