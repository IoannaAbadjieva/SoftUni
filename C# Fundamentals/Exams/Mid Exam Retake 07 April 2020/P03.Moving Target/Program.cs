namespace P03.Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];

                if (type == "Shoot")
                {
                    int indexToShoot = int.Parse(cmdArgs[1]);
                    int power = int.Parse(cmdArgs[2]);

                    if (!IsIndexValid(targets, indexToShoot))
                    {
                        continue;
                    }

                    if (targets[indexToShoot] > power)
                    {
                        targets[indexToShoot] -= power;
                    }
                    else
                    {
                        targets.RemoveAt(indexToShoot);
                    }
                }
                else if (type == "Add")
                {
                    int indexToInsertAt = int.Parse(cmdArgs[1]);
                    int value = int.Parse(cmdArgs[2]);

                    if (!IsIndexValid(targets, indexToInsertAt))
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }

                    targets.Insert(indexToInsertAt, value);
                }
                else if (type == "Strike")
                {
                    int indexToStrike = int.Parse(cmdArgs[1]);
                    int radius = int.Parse(cmdArgs[2]);

                    if (IsStrikeMissed(targets, indexToStrike, radius))
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }

                    int leftMargin = indexToStrike - radius;
                    int countOfStrikes = 2 * radius + 1;

                    for (int count = 1; count <= countOfStrikes; count++)
                    {
                        targets.RemoveAt(leftMargin);
                    }
                }
            }

            Console.WriteLine(String.Join("|", targets));

        }

        static bool IsIndexValid(List<int> lst, int index)
        {
            return index >= 0 && index < lst.Count;
        }

        static bool IsStrikeMissed(List<int> targets, int indexToStrike, int radius)
        {
            int start = indexToStrike - radius;
            int end = indexToStrike + radius;

            bool isStrikeMissed = false;

            for (int index = start; index <= end; index++)
            {
                if (!IsIndexValid(targets, index))
                {
                    isStrikeMissed = true;
                    break;
                }
            }

            return isStrikeMissed;
        }
    }
}
