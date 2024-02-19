namespace P09.Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                string filter = cmdArgs[1];
                string filterValue = cmdArgs[2];

                if (cmdType == "Remove")
                {
                    guests.RemoveAll(SetPredicate(filter, filterValue));
                }
                else if (cmdType == "Double")
                {
                    List<string> guestsToDouble = guests.FindAll(SetPredicate(filter, filterValue));
                    foreach (var guest in guestsToDouble)
                    {
                        int indexToInsertGuest = guests.IndexOf(guest);
                        guests.Insert(indexToInsertGuest, guest);
                    }
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
        }

        static Predicate<string> SetPredicate(string filter, string filterValue)
        {
            if (filter == "StartsWith")
            {
                return x => x.StartsWith(filterValue);
            }
            else if (filter == "EndsWith")
            {
                return x => x.EndsWith(filterValue);
            }
            else
            {
                return x => x.Length == int.Parse(filterValue);
            }
        }
    }
}
