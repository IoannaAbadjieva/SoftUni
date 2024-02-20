namespace ChristmasPastryShop.Models.Cocktails
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Utilities;
    using System;
    using System.Drawing;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.price =  price;
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

        public string Size { get; private set; }

        public double Price => Helper.cocktailPriceMultyplier[this.Size] * this.price;

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
