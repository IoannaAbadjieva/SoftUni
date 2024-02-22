namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double InitialFuel = 65.0;
        private const double RaceFuelConsumption = 7.5;


        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, InitialFuel, RaceFuelConsumption)
        {

        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)Math.Round((0.97 * this.HorsePower), MidpointRounding.AwayFromZero);
        }
    }
}
