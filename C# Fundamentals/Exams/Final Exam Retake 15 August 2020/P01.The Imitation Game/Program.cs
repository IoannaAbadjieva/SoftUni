namespace P01.The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];

                if (cmdType == "Move")
                {
                    int count = int.Parse(cmdArgs[1]);
                    message = MoveLetters(message, count);
                }
                else if (cmdType == "Insert")
                {
                    int indexToInsertAt = int.Parse(cmdArgs[1]);
                    string valueToInsert = cmdArgs[2];


                    if (IsIndexValid(message, indexToInsertAt) || indexToInsertAt == message.Length)
                    {
                        message = message.Insert(indexToInsertAt, valueToInsert);
                    }

                }
                else if (cmdType == "ChangeAll")
                {
                    string substrToChange = cmdArgs[1];
                    string valueToChangeWith = cmdArgs[2];

                    while (message.Contains(substrToChange))
                    {
                        message = message.Replace(substrToChange, valueToChangeWith);
                    }
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string MoveLetters(string message, int count)
        {
            if (count > message.Length)
            {
                count = message.Length;
            }
            string lettersToMove = message.Substring(0, count);
            message = message.Remove(0, count);
            message = message.Insert(message.Length, lettersToMove);
            return message;
        }

        static bool IsIndexValid(string message, int indexToInsertAt)
        {
            return indexToInsertAt >= 0 && indexToInsertAt < message.Length;
        }
    }
}
