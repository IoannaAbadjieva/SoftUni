namespace Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] field = new string[size, size];
            int[] commands = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int totalCountShipsDestroyed = 0;

            for (int row = 0; row < size; row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < line.Length; col++)
                {
                    field[row, col] = line[col];

                    if (line[col] == "<")
                    {
                        firstPlayerShips++;
                    }
                    else if (line[col] == ">")
                    {
                        secondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i += 2)
            {
                int attackedRow = commands[i];
                int attackedCol = commands[i + 1];

                if (!IsIndicesvalid(field, attackedRow, attackedCol))
                {
                    continue;
                }

                if (field[attackedRow, attackedCol] == "#")
                {
                    for (int row = attackedRow - 1; row <= attackedRow + 1; row++)
                    {
                        for (int col = attackedCol - 1; col <= attackedCol + 1; col++)
                        {
                            if (!IsIndicesvalid(field, row, col))
                            {
                                continue;
                            }

                            if (field[row, col] == "<")
                            {
                                firstPlayerShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row, col] == ">")
                            {
                                secondPlayerShips--;
                                totalCountShipsDestroyed++;

                            }
                            field[row, col] = "X";
                        }
                    }

                }
                else if (field[attackedRow, attackedCol] == ">")
                {
                    secondPlayerShips--;
                    totalCountShipsDestroyed++;
                    field[attackedRow, attackedCol] = "X";

                }
                else if (field[attackedRow, attackedCol] == "<")
                {
                    firstPlayerShips--;
                    totalCountShipsDestroyed++;
                    field[attackedRow, attackedCol] = "X";
                }

                if (firstPlayerShips <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }

                if (secondPlayerShips <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }

        static bool IsIndicesvalid(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
