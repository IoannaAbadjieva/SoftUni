namespace ShoppingSpree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        private Person()
        {
            this.bagOfProducts = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.ArgumentEmpty);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExeptionMessages.ArgumentNegative);
                }

                this.money = value;
            }
        }

        public string AddProduct(Product product)
        {
            decimal moneyLeft = this.Money - product.Cost;

            if (moneyLeft >= 0)
            {
                this.bagOfProducts.Add(product);
                this.Money = moneyLeft;
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";

        }

        public override string ToString()
        {
            string productsBought = this.bagOfProducts.Count > 0 ?
                string.Join(", ", this.bagOfProducts.Select(p => p.Name))
                : "Nothing bought";

            return $"{this.Name} - {productsBought}";
        }
    }
}
