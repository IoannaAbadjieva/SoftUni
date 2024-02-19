namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            string[][] jaggedArray = new string[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            int tokens = 0;
            int opponentTokens = 0;

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (cmdType == "Find")
                {
                    if (IsIndicesValid(jaggedArray, row, col))
                    {
                        if (jaggedArray[row][col] == "T")
                        {
                            tokens++;
                            jaggedArray[row][col] = "-";
                        }
                    }

                }
                else if (cmdType == "Opponent")
                {
                    string direction = cmdArgs[3];

                    if (IsIndicesValid(jaggedArray, row, col))
                    {
                        if (jaggedArray[row][col] == "T")
                        {
                            opponentTokens++;
                            jaggedArray[row][col] = "-";
                        }

                        if (direction == "up")
                        {
                            int edge = row - 3 >= 0 ? row - 3 : 0;

                            for (int r = row - 1; r >= edge; r--)
                            {
                                if (jaggedArray[r][col] == "T")
                                {
                                    opponentTokens++;
                                    jaggedArray[r][col] = "-";
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            int edge = row + 3 < jaggedArray.Length ? row + 3 : jaggedArray.Length - 1;

                            for (int r = row + 1; r <= edge; r++)
                            {
                                if (jaggedArray[r][col] == "T")
                                {
                                    opponentTokens++;
                                    jaggedArray[r][col] = "-";
                                }
                            }
                        }
                        else if (direction == "left")
                        {

                            int edge = col - 3 >= 0 ? col - 3 : 0;

                            for (int c = col - 1; c >= edge; c--)
                            {
                                if (jaggedArray[row][c] == "T")
                                {
                                    opponentTokens++;
                                    jaggedArray[row][c] = "-";
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            int edge = col + 3 < jaggedArray[row].Length ? col + 3 : jaggedArray[row].Length - 1;

                            for (int c = col + 1; c <= edge; c++)
                            {
                                if (jaggedArray[row][c] == "T")
                                {
                                    opponentTokens++;
                                    jaggedArray[row][c] = "-";
                                }
                            }
                        }

                    }
                }
            }

            PrintArray(jaggedArray);
            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");

        }

        static bool IsIndicesValid(string[][] array, int row, int col)
        {
            return row >= 0 && row < array.Length
                && col >= 0 && col < array[row].Length;
        }

        static void PrintArray(string[][] array)
        {
            for (int row = 0; row < array.Length; row++)
            {
                Console.WriteLine(String.Join(" ", array[row]));
            }
        }
    }
}
