namespace FoodShortage.Models.Contracts
{
    public interface IRebel : ICitizen, IBuyer
    {
        public string Group { get; }
    }
}
