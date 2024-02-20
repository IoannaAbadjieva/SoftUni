namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialOxygen = 70;
        private const double OxygenDecreasementUnits = 5;

        public Biologist(string name)
            : base(name, InitialOxygen)
        {

        }

        public override void Breath()
        {
            double oxygenLeft = this.Oxygen - OxygenDecreasementUnits;

            if (oxygenLeft < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen = oxygenLeft;
            }
        }

    }
}
