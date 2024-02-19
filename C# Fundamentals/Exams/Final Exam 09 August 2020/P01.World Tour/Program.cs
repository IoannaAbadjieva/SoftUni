namespace P01.World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string stopToAdd = cmdArgs[2];
                    if (IsIndexValid(stops, index))
                    {
                        stops = stops.Insert(index, stopToAdd);
                    }
                    Console.WriteLine(stops);
                }
                else if (cmdType == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if (IsIndexValid(stops, startIndex) && IsIndexValid(stops, endIndex))
                    {
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(stops);
                }
                else if (cmdType == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                    Console.WriteLine(stops);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        static bool IsIndexValid(string stops, int index)
        {
            return index >= 0 && index < stops.Length;
        }
    }
}
