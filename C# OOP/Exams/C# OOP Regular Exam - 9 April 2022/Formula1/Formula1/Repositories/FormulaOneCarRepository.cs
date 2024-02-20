namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;


    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new HashSet<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
            => (IReadOnlyCollection<IFormulaOneCar>)this.cars;

        public void Add(IFormulaOneCar model)
        {
            this.cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        => this.cars.FirstOrDefault(c => c.Model == name);

        public bool Remove(IFormulaOneCar model)
        => this.cars.Remove(model);
    }
}
