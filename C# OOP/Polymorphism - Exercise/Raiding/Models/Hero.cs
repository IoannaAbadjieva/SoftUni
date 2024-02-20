namespace Raiding.Models
{
    using Contracts;

    public abstract class Hero : IHero
    {
        public Hero(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual int Power { get; }

        public  virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} ";
        }
    }
}
