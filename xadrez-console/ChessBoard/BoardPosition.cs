namespace xadrez_console.ChessBoard
{
    internal class BoardPosition
    {
        public int Rank { get; set; }
        public int Column { get; set; }

        public BoardPosition() { }

        public BoardPosition(int rank, int column)
        {
            Rank = rank;
            Column = column;
        }

        public override string ToString()
        {
            return Rank
                + ", "
                + Column;
        }
    }
}