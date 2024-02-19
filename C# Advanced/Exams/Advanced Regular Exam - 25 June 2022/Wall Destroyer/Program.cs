namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int size = int.Parse(Console.ReadLine());
                char[,] wall = new char[size, size];
                int currRow = -1;
                int currCol = -1;

                for (int row = 0; row < size; row++)
                {
                    string rowElements = Console.ReadLine();

                    for (int col = 0; col < size; col++)
                    {
                        wall[row, col] = rowElements[col];

                        if (rowElements[col] == 'V')
                        {
                            currRow = row;
                            currCol = col;
                        }
                    }
                }
                int holesCount = 1;
                int hitedRods = 0;
                bool isElectrocuted = false;

                while (true)
                {
                    string command = Console.ReadLine();

                    int rowOffset = 0;
                    int colOffset = 0;


                    if (command == "End")
                    {
                        break;
                    }

                    if (command == "up")
                    {
                        rowOffset = -1;
                    }
                    else if (command == "down")
                    {
                        rowOffset = 1;
                    }
                    else if (command == "left")
                    {
                        colOffset = -1;
                    }
                    else if (command == "right")
                    {
                        colOffset = 1;
                    }

                    Move(wall, ref currRow, ref currCol, rowOffset, colOffset, ref holesCount, ref hitedRods, ref isElectrocuted);
                    //Console.WriteLine($"holesCount: {holesCount}");
                    //Print(wall);
                    //Console.WriteLine();
                    if (isElectrocuted)
                    {
                        break;
                    }
                }

                if (isElectrocuted)
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                }
                else
                {
                    Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {hitedRods} rod(s).");
                }

                Print(wall);
            }


            static void Move(char[,] wall, ref int currRow, ref int currCol, int rowOffset, int colOffset, ref int holesCount, ref int hitedRods, ref bool isElectrocuted)
            {
                if (!IsIndicesValid(wall, currRow + rowOffset, currCol + colOffset))
                {
                    return;
                }

                if (wall[currRow + rowOffset, currCol + colOffset] == 'R')
                {
                    Console.WriteLine($"Vanko hit a rod!");
                    hitedRods++;
                    return;
                }

                wall[currRow, currCol] = '*';

                currRow += rowOffset;
                currCol += colOffset;

                if (wall[currRow, currCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{currRow}, {currCol}]!");
                    wall[currRow, currCol] = 'V';
                }
                else if (wall[currRow, currCol] == 'C')
                {
                    isElectrocuted = true;
                    wall[currRow, currCol] = 'E';
                    holesCount++;
                }
                else
                {
                    wall[currRow, currCol] = 'V';
                    holesCount++;
                }

            }

            static bool IsIndicesValid(char[,] wall, int row, int col)
            {
                return row >= 0 && row < wall.GetLength(0)
                    && col >= 0 && col < wall.GetLength(1);
            }

            static void Print(char[,] wall)
            {
                for (int row = 0; row < wall.GetLength(0); row++)
                {
                    for (int col = 0; col < wall.GetLength(1); col++)
                    {
                        Console.Write(wall[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
