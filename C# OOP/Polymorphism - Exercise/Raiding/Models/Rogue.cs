namespace Raiding.Models
{

    public class Rogue : Hero
    {
        private const int RougePower = 80;

        public Rogue(string name) 
            : base(name)
        {

        }

        public override int Power => RougePower;

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }

    }
}
