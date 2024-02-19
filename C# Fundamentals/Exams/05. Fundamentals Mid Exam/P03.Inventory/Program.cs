namespace P03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                char[] separators = new char[] { ' ', ',', '-', ':' };

                List<string> inventory = Console.ReadLine()
                     .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                     .ToList();

                string command;

                while ((command = Console.ReadLine()) != "Craft!")
                {
                    string[] cmdArgs = command
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    string cmdType = cmdArgs[0];

                    if (cmdType == "Collect")
                    {
                        string item = cmdArgs[1];

                        if (inventory.Contains(item))
                        {
                            continue;
                        }
                        inventory.Add(item);
                    }
                    else if (cmdType == "Drop")
                    {
                        string item = cmdArgs[1];

                        if (inventory.Contains(item))
                        {
                            inventory.RemoveAll(x => x == item);
                        }
                    }
                    else if (cmdType == "Combine")
                    {
                        string oldItem = cmdArgs[2];
                        string newItem = cmdArgs[3];

                        if (inventory.Contains(oldItem))
                        {
                            int indexOfOldItem = inventory.IndexOf(oldItem);
                            inventory.Insert(indexOfOldItem + 1, newItem);
                        }
                    }
                    else if (cmdType == "Renew")
                    {
                        string item = cmdArgs[1];

                        if (inventory.Contains(item))
                        {
                            inventory.Remove(item);
                            inventory.Add(item);
                        }
                    }
                }

                Console.WriteLine(string.Join(", ", inventory));
            }
        }
    }
