namespace Raiding.Models
{
  
    public class Druid : Hero
    {
        private const int DruidPower = 80;

        public Druid(string name) 
            : base(name)
        {

        }

        public override int Power => DruidPower;

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {Power}";
        }
    }
}
