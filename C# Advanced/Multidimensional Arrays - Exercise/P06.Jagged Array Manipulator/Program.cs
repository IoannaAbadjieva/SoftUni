namespace P06.Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int i = row; i <= row + 1; i++)
                    {
                        for (int j = 0; j < jaggedArray[i].Length; j++)
                        {
                            jaggedArray[i][j] *= 2;
                        }
                    }
                }
                else
                {
                    for (int i = row; i <= row + 1; i++)
                    {
                        for (int j = 0; j < jaggedArray[i].Length; j++)
                        {
                            jaggedArray[i][j] /= 2;
                        }
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (!IsIndexesValid(jaggedArray, row, col))
                {
                    continue;
                }

                if (cmdType == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (cmdType == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }

            }

            PrintJaggedArray(jaggedArray);
        }


        static bool IsIndexesValid(double[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length &&
                   col >= 0 && col < jaggedArray[row].Length;
        }

        static void PrintJaggedArray(double[][] jaggedArray)
        {
            foreach (double[] array in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", array));
            }
        }
    }
}
