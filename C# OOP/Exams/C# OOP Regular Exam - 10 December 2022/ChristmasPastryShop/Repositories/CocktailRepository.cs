namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly ICollection<ICocktail> cocktails;

        public CocktailRepository()
        {
            this.cocktails = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models
            => (IReadOnlyCollection<ICocktail>)this.cocktails;

        public void AddModel(ICocktail model)
        {
            this.cocktails.Add(model);
        }
    }
}
