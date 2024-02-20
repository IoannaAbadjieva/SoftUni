namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Utilities;

    public class Race : IRace
    {
        private const int NameMinLengthValue = 5;
        private const int LapsMinCount = 1;

        private string raceName;
        private int numberOfLaps;
        private readonly ICollection<IPilot> pilots;

        private Race()
        {
            this.pilots = new HashSet<IPilot>();
        }

        public Race(string raceName, int numberOfLaps)
            : this()
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NameMinLengthValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < LapsMinCount)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {
            this.Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"The {this.RaceName} race has:")
                .AppendLine($"Participants: {this.Pilots.Count}")
                .AppendLine($"Number of laps: {this.NumberOfLaps}")
                .AppendLine($"Took place: {(this.TookPlace ? "Yes" : "No")}");

            return sb.ToString().Trim();
        }
    }
}
