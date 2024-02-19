using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count { get { return players.Count; } }

        public string  AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {--OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove != null)
            {
                OpenPositions++;
            }

            return players.Remove(playerToRemove);
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayersCount = players.RemoveAll(p => p.Position == position);
            OpenPositions += removedPlayersCount;
            return removedPlayersCount;
        }

        public Player RetirePlayer(string name)
        {
            Player playerToRetire = players.FirstOrDefault(p => p.Name == name);

            if (playerToRetire != null)
            {
                playerToRetire.Retired = true;
            }

            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players.FindAll(p => p.Games >= games);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (Player player in players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }


    }
}
