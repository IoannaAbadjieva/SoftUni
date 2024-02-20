using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar model)
        {
            this.cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll() 
            => (IReadOnlyCollection<ICar>)this.cars;

        public ICar GetByName(string name)
            => this.cars.FirstOrDefault(c => c.Model == name);

        public bool Remove(ICar model)
            => cars.Remove(model);
    }
}
