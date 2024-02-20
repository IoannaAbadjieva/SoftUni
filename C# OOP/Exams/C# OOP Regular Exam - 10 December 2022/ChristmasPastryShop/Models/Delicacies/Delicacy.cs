namespace ChristmasPastryShop.Models.Delicacies
{
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using System;

    public abstract class Delicacy : IDelicacy
    {
        private string name;

        protected Delicacy(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double Price { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:f2} lv";
        }
    }
}
