namespace Raiding.Models
{

    public class Paladin : Hero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) 
            : base(name)
        {

        }

        public override int Power => PaladinPower;

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {this.Power}";
        }
    }
}
