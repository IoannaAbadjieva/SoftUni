namespace Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());

            char[][] maze = new char[rowsCount][];

            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                maze[row] = Console.ReadLine().ToCharArray();
            }

            for (int row = 0; row < maze.Length; row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = command[0];
                int spawnRow = int.Parse(command[1]);
                int spawnCol = int.Parse(command[2]);

                maze[spawnRow][spawnCol] = 'B';

                int rowShift = 0;
                int colShift = 0;

                if (direction == "W")
                {
                    rowShift--;
                }
                else if (direction == "S")
                {
                    rowShift++;
                }
                else if (direction == "A")
                {
                    colShift--;
                }
                else if (direction == "D")
                {
                    colShift++;
                }

                lives--;
                if (!IsIndicesValid(maze, marioRow + rowShift, marioCol + colShift))
                {
                    continue;
                }

                maze[marioRow][marioCol] = '-';
                marioRow += rowShift;
                marioCol += colShift;

                if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                if (maze[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                }
                maze[marioRow][marioCol] = 'M';

                if (lives <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

            }

            PrintMaze(maze);
        }

        static void PrintMaze(char[][] maze)
        {
            for (int row = 0; row < maze.Length; row++)
            {
                Console.WriteLine(String.Join("", maze[row]));
            }
        }

        static bool IsIndicesValid(char[][] maze, int row, int col)
        {
            return row >= 0 && row < maze.Length
                && col >= 0 && col < maze[row].Length;
        }
    }
}
