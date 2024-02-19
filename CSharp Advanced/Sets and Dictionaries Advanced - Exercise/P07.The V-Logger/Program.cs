namespace P07.The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = cmdArgs[0];
                string cmdType = cmdArgs[1];

                Vlogger vlogger = vloggers.FirstOrDefault(v => v.Name == vloggerName);

                if (cmdType == "joined")
                {
                    if (vlogger == null)
                    {
                        Vlogger newVlogger = new Vlogger(vloggerName);
                        vloggers.Add(newVlogger);
                    }

                }
                else if (cmdType == "followed")
                {
                    string vloggerToFollowName = cmdArgs[2];

                    Vlogger vloggerToFollow = vloggers.FirstOrDefault(v => v.Name == vloggerToFollowName);

                    if (vloggerToFollowName == vloggerName || vlogger == null || vloggerToFollow == null)
                    {
                        continue;
                    }

                    if (!vlogger.Following.Contains(vloggerToFollowName))
                    {
                        vlogger.Following.Add(vloggerToFollowName);
                        vloggerToFollow.Followers.Add(vloggerName);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int counter = 1;

            foreach (var member in vloggers.OrderByDescending(v => v.Followers.Count).ThenBy(v => v.Following.Count))
            {
                Console.WriteLine($"{counter}. {member.Name} : {member.Followers.Count} followers, {member.Following.Count} following");
                if (counter == 1)
                {
                    foreach (var follower in member.Followers.OrderBy(name => name))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }

    class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Followers = new List<string>();
            Following = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Followers { get; set; }

        public List<string> Following { get; set; }


    }
}
