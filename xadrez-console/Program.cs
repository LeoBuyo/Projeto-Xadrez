using System;
using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;
using xadrez_console.ChessPieces;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new King(Color.Black, board), new Position(0, 0));
                board.PutPiece(new Rook(Color.Black, board), new Position(1, 9));
                board.PutPiece(new Pawn(Color.Black, board), new Position(0, 0));

                Screen.PrintBoard(board);
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}