using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> periferals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new HashSet<IComponent>();
            this.periferals = new HashSet<IPeripheral>();
        }

        public override double OverallPerformance
         => base.OverallPerformance
         + (this.components.Any() ? this.components.Average(c => c.OverallPerformance) : 0);

        public override decimal Price
            => base.Price
            + (this.components.Any() ? this.components.Sum(c => c.Price) : 0m)
            + (this.periferals.Any() ? this.periferals.Sum(c => c.Price) : 0m);

        public IReadOnlyCollection<IComponent> Components
            => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => (IReadOnlyCollection<IPeripheral>)this.periferals;
        
        public void AddComponent(IComponent component)
        {
            IComponent searchedComponent = this.components.FirstOrDefault(c => c.GetType() == component.GetType());

            if (searchedComponent != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral searchedPeriferal = this.periferals.FirstOrDefault(c => c.GetType() == peripheral.GetType());

            if (searchedPeriferal != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.periferals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent componentToRemove = this.components
                .FirstOrDefault(c => c.GetType().Name == componentType);

            if (componentToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }

            IComponent component = componentToRemove;
            this.components.Remove(componentToRemove);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral periferalToRemove = this.periferals
               .FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (periferalToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral periferal = periferalToRemove;
            this.periferals.Remove(periferalToRemove);

            return periferal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double avgOverallPerformance = this.Peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0;

            sb
                .AppendLine(base.ToString())
                .AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }
            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({avgOverallPerformance:f2}):");
            foreach (var periferal in this.Peripherals)
            {
                sb.AppendLine($"  {periferal.ToString()}");
            }

            return sb.ToString().Trim();
        }

    }
}
