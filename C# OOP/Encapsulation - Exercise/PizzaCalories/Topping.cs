namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private const int MinToppingWeight = 1;
        private const int MaxToppingWeight = 50;
        private const int BaseCalories = 2;

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get { return this.toppingType; }

            private set
            {
                if (!Helper.Modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidToppingType, value));
                }

                this.toppingType = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }

            private set
            {
                if (value < MinToppingWeight || value > MaxToppingWeight)
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidToppingWeight, this.ToppingType));
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return

                     this.Weight
                    * BaseCalories
                    * Helper.Modifiers[this.ToppingType.ToLower()];
            }
        }
    }
}
