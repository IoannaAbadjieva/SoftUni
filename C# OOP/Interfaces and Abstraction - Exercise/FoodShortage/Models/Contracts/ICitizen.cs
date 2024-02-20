namespace FoodShortage.Models.Contracts
{
    public interface ICitizen:IBuyer
    {
        public string Name { get; }

        public int Age { get; }
    }
}
