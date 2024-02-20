namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Equipment.Contracts;
    using Repositories.Contracts;


    public class EquipmentRepository : IRepository<IEquipment>
    {

        private readonly ICollection<IEquipment> equipment;

        public EquipmentRepository()
        {
            this.equipment = new HashSet<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models
            => (IReadOnlyCollection<IEquipment>)this.equipment;

        public void Add(IEquipment model)
        {
            this.equipment.Add(model);
        }

        public bool Remove(IEquipment model)
        => this.equipment.Remove(model);

        public IEquipment FindByType(string type)
        => this.equipment.FirstOrDefault(e => e.GetType().Name == type);
    }
}
