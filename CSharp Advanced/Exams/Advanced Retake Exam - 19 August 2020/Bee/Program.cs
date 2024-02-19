namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MinCountOfPolinatedFlowers = 5;

            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size, size];

            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    territory[row, col] = line[col];

                    if (line[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command;
            int polinatedFlowers = 0;
            bool hasLost = false;

            while ((command = Console.ReadLine()) != "End")
            {
                BeeMove(territory, ref beeRow, ref beeCol, ref polinatedFlowers, ref hasLost, command);
                if (hasLost)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }

            if (polinatedFlowers >= MinCountOfPolinatedFlowers)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {MinCountOfPolinatedFlowers - polinatedFlowers} flowers more");
            }

            PrintMatrix(territory);
        }

        static bool IsIndicesValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        static void BeeMove(char[,] territory, ref int beeRow, ref int beeCol, ref int polinatedFlowers, ref bool hasLost, string command)
        {
            territory[beeRow, beeCol] = '.';

            if (command == "up")
            {
                beeRow--;
            }
            else if (command == "down")
            {
                beeRow++;
            }
            else if (command == "left")
            {
                beeCol--;
            }
            else if (command == "right")
            {
                beeCol++;
            }

            if (!IsIndicesValid(territory, beeRow, beeCol))
            {
                hasLost = true;
                return;
            }

            if (territory[beeRow, beeCol] == 'f')
            {
                polinatedFlowers++;
            }
            else if (territory[beeRow, beeCol] == 'O')
            {
                BeeMove(territory, ref beeRow, ref beeCol, ref polinatedFlowers, ref hasLost, command);
            }
            territory[beeRow, beeCol] = 'B';
        }

        static void PrintMatrix(char[,] matrix)
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
