namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository:IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models 
            => (IReadOnlyCollection<IPlanet>)this.planets;

        public void AddItem(IPlanet planet)
        {
            this.planets.Add(planet);
        }

        public IPlanet FindByName(string planetName)
            => this.planets.FirstOrDefault(p => p.Name == planetName);

        public bool RemoveItem(string planetName)
            => this.planets.Remove(this.FindByName(planetName));
    }
}

