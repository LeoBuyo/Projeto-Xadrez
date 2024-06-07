using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "N";
        }
    }
}