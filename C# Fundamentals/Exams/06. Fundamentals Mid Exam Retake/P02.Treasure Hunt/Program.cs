namespace P02.Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "Loot")
                {
                    for (int index = 1; index < cmdArgs.Length; index++)
                    {
                        string item = cmdArgs[index];

                        if (treasureChest.Contains(item))
                        {
                            continue;
                        }

                        treasureChest.Insert(0, item);
                    }
                }
                else if (cmdType == "Drop")
                {
                    int indexToDrop = int.Parse(cmdArgs[1]);

                    if (!IsIndexValid(treasureChest, indexToDrop))
                    {
                        continue;
                    }

                    string itemToDrop = treasureChest[indexToDrop];
                    treasureChest.RemoveAt(indexToDrop);
                    treasureChest.Add(itemToDrop);
                }
                else if (cmdType == "Steal")
                {
                    int count = int.Parse(cmdArgs[1]);
                    List<string> stealedItems = new List<string>();

                    StealItems(treasureChest, stealedItems, count);
                    Console.WriteLine(string.Join(", ", stealedItems));
                }
            }

            if (treasureChest.Count > 0)
            {
                int treasureGain = GetTresureGain(treasureChest);
                double averageGain = treasureGain * 1.0 / treasureChest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }

        }

        static bool IsIndexValid(List<string> lst, int index)
        {
            return index >= 0 && index < lst.Count;
        }

        static void StealItems(List<string> treasureChest, List<string> stealedItems, int count)
        {
            int start = treasureChest.Count - count;


            if (start < 0)
            {
                start = 0;
                count = treasureChest.Count;
            }

            for (int i = 0; i < count; i++)
            {
                stealedItems.Add(treasureChest[start]);
                treasureChest.RemoveAt(start);
            }

        }

        static int GetTresureGain(List<string> lst)
        {
            int treasureGain = 0;

            for (int index = 0; index < lst.Count; index++)
            {
                string currItem = lst[index];

                treasureGain += currItem.Length;
            }

            return treasureGain;
        }
    }
}
