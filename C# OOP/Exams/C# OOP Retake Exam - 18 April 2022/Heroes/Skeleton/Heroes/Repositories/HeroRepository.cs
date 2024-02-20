namespace Heroes.Repositories
{
   
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;
  

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new HashSet<IHero>();
        }
        public IReadOnlyCollection<IHero> Models 
            =>(IReadOnlyCollection<IHero>) this.heroes;

        public void Add(IHero model)
        {
            this.heroes.Add(model); 
        }

        public IHero FindByName(string name)
        => this.heroes.FirstOrDefault(h=> h.Name == name);

        public bool Remove(IHero model)
        =>this.heroes.Remove(model);
    }
}
