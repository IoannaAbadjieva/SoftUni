namespace P10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> force = new SortedDictionary<string, SortedSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {

                if (input.Contains("|"))
                {
                    string[] arguments = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = arguments[0];
                    string forceUser = arguments[1];

                    if (!force.Values.Any(x => x.Contains(forceUser)))
                    {
                        if (!force.ContainsKey(forceSide))
                        {
                            force.Add(forceSide, new SortedSet<string>());
                        }

                        force[forceSide].Add(forceUser);
                    }

                }
                else
                {
                    string[] arguments = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = arguments[1];
                    string forceUser = arguments[0];

                    foreach (var users in force.Values)
                    {
                        if (users.Contains(forceUser))
                        {
                            users.Remove(forceUser);
                            break;
                        }
                    }

                    if (!force.ContainsKey(forceSide))
                    {
                        force.Add(forceSide, new SortedSet<string>());
                    }

                    force[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var orderedForceUsers = force.OrderByDescending(x => x.Value.Count);

            foreach (var side in orderedForceUsers)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
