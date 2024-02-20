using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> periferals;
        private readonly ICollection<IComputer> computers;

        public Controller()
        {
            this.components = new HashSet<IComponent>();
            this.periferals = new HashSet<IPeripheral>();
            this.computers = new HashSet<IComputer>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            computer = computerType switch
            {
                nameof(DesktopComputer) => new DesktopComputer(id, manufacturer, model, price),
                nameof(Laptop) => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            this.computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }


            IComponent component = componentType switch
            {
                nameof(CentralProcessingUnit) => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                nameof(Motherboard) => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                nameof(SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                nameof(VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computer.AddComponent(component);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent removedComponent = computer.RemoveComponent(componentType);
            this.components.Remove(removedComponent);

            return string.Format(SuccessMessages.RemovedComponent, componentType, removedComponent.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.periferals.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral periferal = peripheralType switch
            {
                nameof(Headset) => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }


            computer.AddPeripheral(periferal);
            this.periferals.Add(periferal);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral removedPeriferal = computer.RemovePeripheral(peripheralType);
            this.periferals.Remove(removedPeriferal);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, removedPeriferal.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            string result = computer.ToString();

            foreach (var component in computer.Components)
            {
                this.components.Remove(component);
            }

            foreach (var peripheral in computer.Peripherals)
            {
                this.periferals.Remove(peripheral);
            }

            this.computers.Remove(computer);

            return result;
        }

        public string BuyBest(decimal budget)
        {
            IComputer[] bestPerformedComputers = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .ThenBy(c => c.Price)
                .Where(c => c.Price <= budget)
                .ToArray();

            if (!bestPerformedComputers.Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            string result = bestPerformedComputers[0].ToString();
            this.computers.Remove(bestPerformedComputers[0]);

            foreach (var component in bestPerformedComputers[0].Components)
            {
                this.components.Remove(component);
            }

            foreach (var peripheral in bestPerformedComputers[0].Peripherals)
            {
                this.periferals.Remove(peripheral);
            }

            return result;
        }

        public string GetComputerData(int id)
        {

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }

    }
}
