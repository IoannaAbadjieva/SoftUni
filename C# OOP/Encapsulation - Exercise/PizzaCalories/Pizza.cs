namespace PizzaCalories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Pizza
    {
        private int MinPizzaNameLength = 1;
        private int MaxPizzaNameLength = 15;

        private string name;
        private List<Topping> toppings;

        private Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
            : this()
        {
            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value)
                    || value.Length < MinPizzaNameLength
                    || value.Length > MaxPizzaNameLength)
                {
                    throw new ArgumentException(ExeptionMessages.InvalidPizzaName);
                }

                this.name = value;
            }
        }

        public Dough Dough { get; private set; }

        public double Calories
        {
            get
            {
                return this.Dough.Calories + this.toppings.Sum(t => t.Calories);
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException(ExeptionMessages.InvalidToppingsCount);
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories.";
        }

    }
}
