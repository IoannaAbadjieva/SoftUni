namespace Gym.Models.Athletes
{
    using System;
    
    using Utilities.Messages;

    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        private const int StaminaIncreasePoints = 15;

        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {

        }

        public override void Exercise()
        {
            this.Stamina += StaminaIncreasePoints;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
