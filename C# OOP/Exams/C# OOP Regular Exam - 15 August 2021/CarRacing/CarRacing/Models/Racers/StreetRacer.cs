namespace CarRacing.Models.Racers
{
    using Cars.Contracts;
   
    public class StreetRacer:Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string Behavior = "aggressive";
        private const int ExperienceEncreasementStep = 5;

        public StreetRacer(string username, ICar car)
            : base(username, Behavior, InitialDrivingExperience, car)
        {

        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += ExperienceEncreasementStep;
        }
    }
}
