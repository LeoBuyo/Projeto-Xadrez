using xadrez_console.ChessBoard;

namespace xadrez_console.ChessPieces
{
    internal class PiecePosition
    {
        public char Column { get; set; }
        public  int Rank { get; set; }

        public PiecePosition () { }

        public PiecePosition(char column, int rank)
        {
            Column = column;
            Rank = rank;
        }

        public BoardPosition ToPosition()
        {
            return new BoardPosition(8 - Rank, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Rank;
        }
    }

}
