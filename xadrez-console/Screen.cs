using System;
using xadrez_console.ChessBoard.Enums;
using xadrez_console.ChessBoard;
using xadrez_console.ChessPieces;

namespace xadrez_console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Ranks; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Pieces[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possibleMovements)
        {

            ConsoleColor OriginalBackGround = Console.BackgroundColor;
            ConsoleColor AlteredBackGround = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Ranks; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMovements[i, j])
                    {
                        Console.BackgroundColor = AlteredBackGround;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackGround;
                    }
                    PrintPiece(board.Pieces[i, j]);
                    Console.BackgroundColor = OriginalBackGround;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = OriginalBackGround;
        }

        public static PiecePosition ReadPiecePosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int rank = int.Parse(s[1] + " ");
            return new PiecePosition(column, rank);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor temp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = temp;
                }
                Console.Write(" ");
            }
        }
    }
}
