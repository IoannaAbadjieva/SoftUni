namespace P10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladybugsIndexes = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            int[] field = new int[fieldSize];

            for (int index = 0; index < fieldSize; index++)
            {
                if (ladybugsIndexes.Contains(index))
                {
                    field[index] = 1;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int ladybugIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int flyLenght = int.Parse(cmdArgs[2]);

                if (ladybugIndex < 0 || ladybugIndex >= fieldSize)
                {
                    continue;
                }

                if (field[ladybugIndex] == 0)
                {
                    continue;
                }
                int landingIndex = ladybugIndex;

                while (true)
                {
                    field[ladybugIndex] = 0;

                    if (direction == "left")
                    {
                        landingIndex -= flyLenght;
                    }
                    else if (direction == "right")
                    {
                        landingIndex += flyLenght;
                    }

                    if (landingIndex < 0 || landingIndex >= fieldSize)
                    {
                        break;
                    }
                    if (field[landingIndex] == 0)
                    {
                        break;
                    }
                }


                if (landingIndex >= 0 && landingIndex < fieldSize)
                {
                    field[landingIndex] = 1;
                }
            }

            Console.WriteLine(string.Join(' ', field));
        }
    }
}
