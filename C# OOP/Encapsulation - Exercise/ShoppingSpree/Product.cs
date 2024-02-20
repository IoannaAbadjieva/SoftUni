namespace ShoppingSpree
{
    using System;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name,decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get { return this.cost; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExeptionMessages.ArgumentNegative);
                } 

                this.cost = value;
            }
        }
    }
}
