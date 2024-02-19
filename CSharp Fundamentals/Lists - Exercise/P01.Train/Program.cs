namespace P01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArgs.Length == 2)
                {
                    int newWagon = int.Parse(cmdArgs[1]);
                    train.Add(newWagon);
                }
                else
                {
                    int passengers = int.Parse(cmdArgs[0]);
                    FindWagonToFit(train, wagonCapacity, passengers);
                }
            }
            Console.WriteLine(string.Join(" ", train));
        }

        static void FindWagonToFit(List<int> train, int wagonCapacity, int passengers)
        {
            for (int index = 0; index < train.Count; index++)
            {
                if (train[index] + passengers <= wagonCapacity)
                {
                    train[index] += passengers;
                    break;
                }
            }
        }
    }
}
