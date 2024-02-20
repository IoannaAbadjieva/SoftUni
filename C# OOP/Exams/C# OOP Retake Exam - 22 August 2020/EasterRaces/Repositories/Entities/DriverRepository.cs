using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly ICollection<IDriver> driverRepository;

        public DriverRepository()
        {
            this.driverRepository = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            this.driverRepository.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        => (IReadOnlyCollection<IDriver>)this.driverRepository;

        public IDriver GetByName(string name)
        => this.driverRepository.FirstOrDefault(d => d.Name == name);    

        public bool Remove(IDriver model)
        =>this.driverRepository.Remove(model);
    }
}
