using System;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessBoard
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMovement { get; protected set; }
        public Board Board { get; protected set; }
        public Piece() { }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            QtyMovement = 0;
            Board = board;
        }
    }
}
