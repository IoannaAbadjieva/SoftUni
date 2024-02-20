namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;


    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new HashSet<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
            => (IReadOnlyCollection<IDecoration>)this.decorations;

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        => this.decorations.FirstOrDefault(d => d.GetType().Name == type);

        public bool Remove(IDecoration model)
        => this.decorations.Remove(model);
    }
}
