namespace P03.The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> piecesList = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] piecesInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                piecesList[piecesInfo[0]] = $"{piecesInfo[1]}:{piecesInfo[2]}";
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                                   .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string piece = cmdArgs[1];

                if (cmdType == "Add")
                {
                    string composer = cmdArgs[2];
                    string pieceKey = cmdArgs[3];

                    if (!piecesList.ContainsKey(piece))
                    {
                        piecesList[piece] = $"{composer}:{pieceKey}";
                        Console.WriteLine($"{piece} by {composer} in {pieceKey} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (cmdType == "Remove")
                {
                    if (piecesList.ContainsKey(piece))
                    {
                        piecesList.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (cmdType == "ChangeKey")
                {
                    string newPieseKey = cmdArgs[2];

                    if (piecesList.ContainsKey(piece))
                    {
                        piecesList[piece] = $"{piecesList[piece].Split(':')[0]}:{newPieseKey}";
                        Console.WriteLine($"Changed the key of {piece} to {newPieseKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var kvp in piecesList)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Split(':')[0]}, Key: {kvp.Value.Split(':')[1]}");
            }
        }
    }
}
