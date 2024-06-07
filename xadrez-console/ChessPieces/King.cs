using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
