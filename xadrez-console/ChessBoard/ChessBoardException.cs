using System;

namespace xadrez_console.ChessBoard
{
    internal class ChessBoardException : Exception
    {
        public ChessBoardException(string msg) : base(msg)
        {
        }
    }
}
