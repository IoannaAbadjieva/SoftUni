namespace AnimalFarm.Models.Contracts
{

    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
