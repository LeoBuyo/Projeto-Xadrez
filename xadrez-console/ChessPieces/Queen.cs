using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
        private bool CanMove(BoardPosition pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Ranks, Board.Columns];

            return matrix;
        }
    }
}