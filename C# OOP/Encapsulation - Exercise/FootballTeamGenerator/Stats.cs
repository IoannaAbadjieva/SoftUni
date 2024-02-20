namespace FootballTeamGenerator
{
    using System;

    public class Stats
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get { return this.endurance; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStat,
                        nameof(this.Endurance),MinStatValue,MaxStatValue));
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStat,
                        nameof(this.Sprint), MinStatValue, MaxStatValue));
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStat,
                        nameof(this.Dribble), MinStatValue, MaxStatValue));
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStat,
                        nameof(this.Passing), MinStatValue, MaxStatValue));
                }

                this.passing = value;
            }

        }

        public int Shooting
        {
            get { return this.shooting; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStat,
                        nameof(this.Shooting), MinStatValue, MaxStatValue));
                }

                this.shooting = value;
            }
        }

        private bool IsStatInvalid(int value)
        {
            return value < MinStatValue || value > MaxStatValue;
        }
    }
}
