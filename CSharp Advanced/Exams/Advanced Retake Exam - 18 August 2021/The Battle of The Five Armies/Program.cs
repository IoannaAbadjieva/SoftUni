namespace The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());

            char[][] field = new char[rowsCount][];

            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();
            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }

            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = command[0];
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                field[enemyRow][enemyCol] = 'O';

                int rowShift = 0;
                int colShift = 0;

                if (direction == "up")
                {
                    rowShift--;
                }
                else if (direction == "down")
                {
                    rowShift++;
                }
                else if (direction == "left")
                {
                    colShift--;
                }
                else if (direction == "right")
                {
                    colShift++;
                }


                if (!IsIndicesValid(field, armyRow + rowShift, armyCol + colShift))
                {
                    if (--armor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        field[armyRow][armyCol] = 'X';
                        break;
                    }
                    continue;
                }

                armor--;
                field[armyRow][armyCol] = '-';
                armyRow += rowShift;
                armyCol += colShift;


                if (field[armyRow][armyCol] == 'M')
                {
                    field[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }
                else
                {
                    if (field[armyRow][armyCol] == 'O')
                    {
                        armor -= 2;
                    }

                    if (armor <= 0)
                    {
                        field[armyRow][armyCol] = 'X';
                        Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                        break;
                    }

                    field[armyRow][armyCol] = 'A';
                }
            }
            PrintArray(field);
        }

        static bool IsIndicesValid(char[][] array, int row, int col)
        {
            return row >= 0 && row < array.Length
                && col >= 0 && col < array[row].Length;
        }

        static void PrintArray(char[][] array)
        {
            for (int row = 0; row < array.Length; row++)
            {
                Console.WriteLine(String.Join("", array[row]));
            }
        }
    }
}
