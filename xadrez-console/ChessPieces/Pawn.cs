using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}