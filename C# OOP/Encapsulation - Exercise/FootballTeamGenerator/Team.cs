namespace FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get 
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Average(p => p.SkillLevel));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExeptionMessages.RemoveUnexistingPlayer,playerName,this.Name));
            }

            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
