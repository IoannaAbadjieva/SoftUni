namespace P10.The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] cmdArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                string filter = cmdArgs[1];
                string filterValue = cmdArgs[2];

                if (cmdType == "Add filter")
                {
                    filters.Add($"{filter} {filterValue}", SetPredicate(filter, filterValue));
                }
                else if (cmdType == "Remove filter")
                {
                    filters.Remove($"{filter} {filterValue}");
                }
            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", guests));
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
            else if (filter == "Lenght")
            {
                return x => x.Length == int.Parse(filterValue);
            }
            else
            {
                return x => x.Contains(filterValue);
            }
        }
    }
}
