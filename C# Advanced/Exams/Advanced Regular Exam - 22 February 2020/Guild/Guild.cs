using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(p => p.Name == name));
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank == "Trial")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank == "Member")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] result = roster.Where(p => p.Class == @class).ToArray();
            roster.RemoveAll(p => p.Class == @class);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
