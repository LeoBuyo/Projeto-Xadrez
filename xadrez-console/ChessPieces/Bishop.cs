using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}