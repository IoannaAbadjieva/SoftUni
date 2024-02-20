namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Heroes.Models.Contracts;


    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
            => (IReadOnlyCollection<IWeapon>)this.weapons;

        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        => this.weapons.FirstOrDefault(w => w.Name == name);

        public bool Remove(IWeapon model)
        => this.weapons.Remove(model);
    }
}
