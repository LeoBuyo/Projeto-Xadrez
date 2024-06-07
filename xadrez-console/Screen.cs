using System;
using xadrez_console.ChessBoard.Enums;
using xadrez_console.ChessBoard;

namespace xadrez_console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Ranks;  i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Pieces[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Pieces[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
