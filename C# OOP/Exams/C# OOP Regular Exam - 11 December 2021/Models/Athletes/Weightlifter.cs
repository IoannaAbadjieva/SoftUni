namespace Gym.Models.Athletes
{
    using System;
   
    using Utilities.Messages;

    public class Weightlifter:Athlete
    {
        private const int InitialStamina = 50;
        private const int StaminaIncreasePoints = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
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
