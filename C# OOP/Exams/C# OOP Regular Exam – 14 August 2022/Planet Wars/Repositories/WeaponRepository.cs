namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Weapons.Contracts;
      

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models 
            => (IReadOnlyCollection<IWeapon>)this.weapons;

        public void AddItem(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IWeapon FindByName(string weaponTypeName) 
            => this.weapons.FirstOrDefault(w => w.GetType().Name == weaponTypeName);

        public bool RemoveItem(string weaponTypeName)
            => this.weapons.Remove(FindByName(weaponTypeName));
    }
}
