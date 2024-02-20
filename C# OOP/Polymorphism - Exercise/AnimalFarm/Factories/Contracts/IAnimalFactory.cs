namespace AnimalFarm.Factories.Contracts
{
    using Models.Contracts;

    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] arguments);
    }
}
