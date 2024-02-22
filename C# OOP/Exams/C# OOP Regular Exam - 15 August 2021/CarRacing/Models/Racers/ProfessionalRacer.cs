namespace CarRacing.Models.Racers
{
    using Cars.Contracts;
    
    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string Behavior = "strict";
        private const int ExperienceEncreasementStep = 10;

        public ProfessionalRacer(string username, ICar car)
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
