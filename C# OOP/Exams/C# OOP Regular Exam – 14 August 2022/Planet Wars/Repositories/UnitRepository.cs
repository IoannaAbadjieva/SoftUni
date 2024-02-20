namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.MilitaryUnits.Contracts;


    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
            => (IReadOnlyCollection<IMilitaryUnit>)this.units;

        public void AddItem(IMilitaryUnit unit)
        {
            this.units.Add(unit);
        }

        public IMilitaryUnit FindByName(string unitTypeName)
            => this.units.FirstOrDefault(u => u.GetType().Name == unitTypeName);

        public bool RemoveItem(string unitTypeName)
            => this.units.Remove(FindByName(unitTypeName));
    }
}
