using System.Text;

namespace P05.Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());
            RegisterTeam(teams, n);
            AddMember(teams);

            List<Team> validTeams = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();

            List<Team> disbandTeams = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.Name)
                .ToList();

            validTeams.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Teams to disband:");
            disbandTeams.ForEach(x => Console.WriteLine(x.Name));
        }

        static void RegisterTeam(List<Team> teams, int n)
        {

            for (int i = 1; i <= n; i++)
            {
                string[] teamArgs = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string creatorName = teamArgs[0];
                string teamName = teamArgs[1];

                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team newTeam = new Team(teamName, creatorName);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }
        }

        static void AddMember(List<Team> teams)
        {
            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] membersArgs = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string memberName = membersArgs[0];
                string teamName = membersArgs[1];

                Team searchedTeam = teams.FirstOrDefault(x => x.Name == teamName);
                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Members.Contains(memberName)) || teams.Any(x => x.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                searchedTeam.Members.Add(memberName);
            }
        }
    }
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine($"- {Creator}");

            foreach (string currMember in Members.OrderBy(x => x))
            {
                sb.AppendLine($"-- {currMember}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
