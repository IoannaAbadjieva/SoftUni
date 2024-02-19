using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                if (cmdType == "Push")
                {
                    string[] itemsToPush = cmdArgs.Skip(1).ToArray();

                    foreach (var item in itemsToPush)
                    {
                        stack.Push(item);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception exeption)
                    {
                        Console.WriteLine(exeption.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
