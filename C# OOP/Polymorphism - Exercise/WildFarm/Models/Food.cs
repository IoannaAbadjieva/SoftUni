namespace WildFarm.Models
{

    using Contracts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
