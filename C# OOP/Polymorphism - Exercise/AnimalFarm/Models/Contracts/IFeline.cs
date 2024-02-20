namespace AnimalFarm.Models.Contracts
{

    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
