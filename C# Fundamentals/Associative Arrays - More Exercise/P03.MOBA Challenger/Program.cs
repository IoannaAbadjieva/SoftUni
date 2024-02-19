using System.Text;

namespace P03.MOBA_Challenger
{
    class Player
    {
        public Player(string name, string position, int points)
        {
            Name = name;
            Levels = new Dictionary<string, int>();
            Levels.Add(position, points);
        }

        public string Name { get; set; }

        public Dictionary<string, int> Levels { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name}: {Levels.Values.Sum()} skill");

            foreach (var level in Levels.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                sb.AppendLine($"- {level.Key} <::> {level.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] cmdArgs = command
                    .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[1] != "vs")
                {
                    ProccessPlayers(cmdArgs, players);
                }
                else
                {
                    DuelPlayers(cmdArgs, players);
                }
            }
            PrintPlayers(players);
        }

        static void ProccessPlayers(string[] cmdArgs, List<Player> players)
        {
            string playername = cmdArgs[0];
            string position = cmdArgs[1];
            int points = int.Parse(cmdArgs[2]);

            Player currPlayer = players.FirstOrDefault(x => x.Name == playername);
            if (currPlayer == null)
            {
                Player newPlayer = new Player(playername, position, points);
                players.Add(newPlayer);
            }
            else
            {
                bool firstCondition = currPlayer.Levels.ContainsKey(position)
                    && currPlayer.Levels[position] < points;

                bool secondCondition = !currPlayer.Levels.ContainsKey(position);

                if (firstCondition || secondCondition)
                {
                    currPlayer.Levels[position] = points;
                }
            }
        }

        static void DuelPlayers(string[] cmdArgs, List<Player> players)
        {
            string firstPlayerName = cmdArgs[0];
            string secondPlayerName = cmdArgs[2];

            Player firstPlayer = players.FirstOrDefault(x => x.Name == firstPlayerName);
            Player secondPlayer = players.FirstOrDefault(x => x.Name == secondPlayerName);

            if (firstPlayer != null && secondPlayer != null)
            {
                string commonPosition = FindCommonPosition(firstPlayer, secondPlayer);

                if (!String.IsNullOrEmpty(commonPosition))
                {
                    int firstPlayerPoints = firstPlayer.Levels.Values.Sum();
                    int secondPlayerPoints = secondPlayer.Levels.Values.Sum();

                    if (firstPlayerPoints < secondPlayerPoints)
                    {
                        players.Remove(firstPlayer);
                    }
                    else if (secondPlayerPoints < firstPlayerPoints)
                    {
                        players.Remove(secondPlayer);
                    }
                }
            }
        }

        static string FindCommonPosition(Player firstPlayer, Player secondPlayer)
        {
            string commonPosition = string.Empty;

            string[] firstPlayerPositions = firstPlayer.Levels.Keys.ToArray();
            string[] secondPlayerPositions = secondPlayer.Levels.Keys.ToArray();

            for (int i = 0; i < firstPlayerPositions.Length; i++)
            {
                string currPosition = firstPlayerPositions[i];
                if (secondPlayerPositions.Contains(currPosition))
                {
                    commonPosition = currPosition;
                    break;
                }
            }
            return commonPosition;
        }

        static void PrintPlayers(List<Player> players)
        {
            foreach (var player in players.OrderByDescending(x => x.Levels.Values.Sum()).ThenBy(x => x.Name))
            {
                Console.WriteLine(player);
            }
        }
    }
}
