namespace Raiding.Factories.Contracts
{
    using Models.Contracts;

    public interface IHeroFactory
    {
        IHero CreateHero(string type,string name);
    }
}
