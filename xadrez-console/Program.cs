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
            PiecePosition pos = new PiecePosition('c', 7);

            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosition());
        }
    }
}