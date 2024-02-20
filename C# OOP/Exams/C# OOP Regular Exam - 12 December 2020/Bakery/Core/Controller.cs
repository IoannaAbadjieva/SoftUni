namespace Bakery.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;

    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                nameof(Tea) => new Tea(name, portion, brand),
                nameof(Water) => new Water(name, portion, brand),
                _ => throw new ArgumentException()
            };

            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = type switch
            {
                nameof(Bread) => new Bread(name, price),
                nameof(Cake) => new Cake(name, price),
                _ => throw new ArgumentException()
            };

            this.bakedFoods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                nameof(InsideTable) => new InsideTable(tableNumber, capacity),
                nameof(OutsideTable) => new OutsideTable(tableNumber, capacity),
                _ => throw new ArgumentException()
            };

            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            var freeTables = this.tables.Where(t => !t.IsReserved);

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.First(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber}"
                + Environment.NewLine
                + $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
