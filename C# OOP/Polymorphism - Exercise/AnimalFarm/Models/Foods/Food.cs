namespace AnimalFarm.Models.Foods
{
    using AnimalFarm.Models.Contracts;
   
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity {get; private set;}
    }
}
