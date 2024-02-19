namespace P02.Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
       .Split("!", StringSplitOptions.RemoveEmptyEntries)
       .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Urgent")
                {
                    string item = cmdArgs[1];

                    if (shoppingList.Contains(item))
                    {
                        continue;
                    }

                    shoppingList.Insert(0, item);
                }
                else if (cmdType == "Unnecessary")
                {
                    string item = cmdArgs[1];

                    if (!shoppingList.Contains(item))
                    {
                        continue;
                    }

                    shoppingList.Remove(item);
                }
                else if (cmdType == "Correct")
                {
                    string item = cmdArgs[1];
                    string newItem = cmdArgs[2];

                    if (!shoppingList.Contains(item))
                    {
                        continue;
                    }

                    shoppingList[shoppingList.IndexOf(item)] = newItem;
                }
                else if (cmdType == "Rearrange")
                {
                    string item = cmdArgs[1];

                    if (!shoppingList.Contains(item))
                    {
                        continue;
                    }

                    shoppingList.Remove(item);
                    shoppingList.Add(item);
                }
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
