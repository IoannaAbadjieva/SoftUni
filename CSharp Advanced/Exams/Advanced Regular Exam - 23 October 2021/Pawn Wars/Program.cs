namespace Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] chessboard = new string[8, 8];

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = $"{(char)(col + 97)}{chessboard.GetLength(0) - row}";
                }
            }

            char[,] board = new char[8, 8];

            int whitePawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = line[col];

                    if (line[col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawnCol = col;
                    }
                    else if (line[col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                }
            }

            while (true)
            {
                if (IsIndicesValid(board, whitePawnRow - 1, whitePawnCol - 1) && board[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {chessboard[whitePawnRow - 1, whitePawnCol - 1]}.");
                    break;
                }
                else if (IsIndicesValid(board, whitePawnRow - 1, whitePawnCol + 1) && board[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {chessboard[whitePawnRow - 1, whitePawnCol + 1]}.");
                    break;
                }
                else
                {
                    board[whitePawnRow, whitePawnCol] = '-';
                    whitePawnRow--;
                    if (whitePawnRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessboard[whitePawnRow, whitePawnCol]}.");
                        break;
                    }
                    board[whitePawnRow, whitePawnCol] = 'w';
                }

                if (IsIndicesValid(board, blackPawnRow + 1, blackPawnCol - 1) && board[blackPawnRow + 1, blackPawnCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {chessboard[blackPawnRow + 1, blackPawnCol - 1]}.");
                    break;
                }
                else if (IsIndicesValid(board, blackPawnRow + 1, blackPawnCol + 1) && board[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {chessboard[blackPawnRow + 1, blackPawnCol + 1]}.");
                    break;
                }
                else
                {
                    board[blackPawnRow, blackPawnCol] = '-';
                    blackPawnRow++;
                    if (blackPawnRow == board.GetLength(0) - 1)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessboard[blackPawnRow, blackPawnCol]}.");
                        break;
                    }
                    board[blackPawnRow, blackPawnCol] = 'b';
                }
            }
        }


        static bool IsIndicesValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
