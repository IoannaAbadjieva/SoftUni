namespace FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static List<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();



            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(';');

                string cmdType = cmdArgs[0];
                string teamName = cmdArgs[1];

                try
                {
                    if (cmdType == "Team")
                    {
                        AddTeam(teamName);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(cmdArgs, teamName);
                    }
                    else if (cmdType == "Remove")
                    {
                        string playerName = cmdArgs[2];
                        RemovePlayerFromTeam(teamName, playerName);
                    }
                    else if (cmdType == "Rating")
                    {
                        RateTeam(teamName);
                    }
                }
                catch (Exception exeption)
                {

                    Console.WriteLine(exeption.Message);
                }
            }

            static void AddTeam(string teamName)
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }

            static void AddPlayerToTeam(string[] cmdArgs, string teamName)
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new InvalidOperationException(string.Format(ExeptionMessages.UnexistingTeam, teamName));
                }

                Player newPlayer = CreateNewPlayer(cmdArgs);
                team.AddPlayer(newPlayer);
            }

            static Player CreateNewPlayer(string[] cmdArgs)
            {
                string playerName = cmdArgs[2];
                int endurance = int.Parse(cmdArgs[3]);
                int sprint = int.Parse(cmdArgs[4]);
                int dribble = int.Parse(cmdArgs[5]);
                int passing = int.Parse(cmdArgs[6]);
                int shooting = int.Parse(cmdArgs[7]);

                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                return player;
            }

            static void RemovePlayerFromTeam(string teamName, string playerName)
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new InvalidOperationException(string.Format(ExeptionMessages.UnexistingTeam, teamName));
                }

                team.RemovePlayer(playerName);
            }

            static void RateTeam(string teamName)
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new InvalidOperationException(string.Format(ExeptionMessages.UnexistingTeam, teamName));
                }

                Console.WriteLine(team.ToString());
            }
        }
    }
}
