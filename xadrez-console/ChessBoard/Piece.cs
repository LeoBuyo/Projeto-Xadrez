using System;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessBoard
{
    internal class Piece
    {
        public BoardPosition Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementCount { get; protected set; }
        public Board Board { get; protected set; }
        public Piece() { }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            MovementCount = 0;
            Board = board;
        }

        public void MovementCountIncrement()
        {
            MovementCount++;
        }
    }
}
