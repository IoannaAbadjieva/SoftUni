namespace Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            string[,] route = new string[size, size];
            int[] tunnelCoordinates = new int[4];
            int index = 0;

            for (int row = 0; row < route.GetLength(0); row++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < route.GetLength(1); col++)
                {
                    route[row, col] = line[col];
                    if (line[col] == "T")
                    {
                        tunnelCoordinates[index++] = row;
                        tunnelCoordinates[index++] = col;
                    }
                }
            }

            string command;
            int kilometersPassed = 0;
            bool hasFinished = false;

            int racerRow = 0;
            int racerCol = 0;

            if (route[racerRow, racerCol] == "F")
            {
                route[racerRow, racerCol] = "C";
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                Console.WriteLine($"Distance covered {kilometersPassed} km.");
                PrintMatrix(route);
                return;
            }
            else if (route[racerRow, racerCol] == "T")
            {
                kilometersPassed += 30;
                route[racerRow, racerCol] = ".";
                racerRow = racerRow == tunnelCoordinates[0] ? tunnelCoordinates[2] : tunnelCoordinates[0];
                racerCol = racerCol == tunnelCoordinates[1] ? tunnelCoordinates[3] : tunnelCoordinates[1];
                route[racerRow, racerCol] = ".";
            }
            else
            {
                route[racerRow, racerCol] = "C";
            }

            while ((command = Console.ReadLine()) != "End")
            {
                route[racerRow, racerCol] = ".";

                if (command == "up")
                {
                    racerRow--;
                }
                else if (command == "down")
                {
                    racerRow++;
                }
                else if (command == "left")
                {
                    racerCol--;
                }
                else if (command == "right")
                {
                    racerCol++;
                }


                if (route[racerRow, racerCol] == "F")
                {
                    kilometersPassed += 10;
                    route[racerRow, racerCol] = "C";
                    hasFinished = true;
                    break;
                }
                else if (route[racerRow, racerCol] == "T")
                {
                    kilometersPassed += 30;
                    route[racerRow, racerCol] = ".";
                    racerRow = racerRow == tunnelCoordinates[0] ? tunnelCoordinates[2] : tunnelCoordinates[0];
                    racerCol = racerCol == tunnelCoordinates[1] ? tunnelCoordinates[3] : tunnelCoordinates[1];
                    route[racerRow, racerCol] = ".";
                }
                else
                {
                    kilometersPassed += 10;
                    route[racerRow, racerCol] = "C";
                }
            }

            if (hasFinished)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometersPassed} km.");

            PrintMatrix(route);
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
