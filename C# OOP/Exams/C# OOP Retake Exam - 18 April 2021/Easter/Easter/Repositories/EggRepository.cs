namespace Easter.Repositories
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new HashSet<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models
            => (IReadOnlyCollection<IEgg>)this.eggs;

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }

        public IEgg FindByName(string name)
        => this.eggs.FirstOrDefault(e => e.Name == name);

        public bool Remove(IEgg model)
        =>this.eggs.Remove(model);
    }
}
