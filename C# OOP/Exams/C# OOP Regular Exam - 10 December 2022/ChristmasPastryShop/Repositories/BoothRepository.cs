namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoothRepository : IRepository<IBooth>
    {
        private readonly ICollection<IBooth> booths;

        public BoothRepository()
        {
            this.booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models 
            => (IReadOnlyCollection<IBooth>)this.booths;

        public void AddModel(IBooth model)
        {
            this.booths.Add(model);
        }
    }
}
