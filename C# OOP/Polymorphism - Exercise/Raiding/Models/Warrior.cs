namespace Raiding.Models
{

    public class Warrior : Hero
    {
        private const int WarriorPower = 100;

        public Warrior(string name) 
            : base(name)
        {

        }

        public override int Power => WarriorPower;

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }
    }
}
