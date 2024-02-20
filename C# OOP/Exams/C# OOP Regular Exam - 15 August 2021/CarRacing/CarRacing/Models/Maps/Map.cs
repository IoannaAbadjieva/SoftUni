namespace CarRacing.Models.Maps
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Racers.Contracts;
    using Utilities.Messages;


    public class Map : IMap
    {
        private static Dictionary<string, double> racingBehaviorMultiplier = new Dictionary<string, double>()
        {
            { "strict", 1.2 },
            { "aggressive", 1.1 },
        };

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else
            {
               
                double racerOneChanceOfWinning = racerOne.Car.HorsePower
                                                 * racerOne.DrivingExperience
                                                 * racingBehaviorMultiplier[racerOne.RacingBehavior]; 

                double racerTwoChanceOfWinning = racerTwo.Car.HorsePower
                                                 * racerTwo.DrivingExperience
                                                 * racingBehaviorMultiplier[racerTwo.RacingBehavior];

                string winnerName = racerOneChanceOfWinning > racerTwoChanceOfWinning ? racerOne.Username : racerTwo.Username;

                racerOne.Race();
                racerTwo.Race();

                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerName);
            }

        }
    }
}
