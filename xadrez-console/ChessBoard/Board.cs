namespace xadrez_console.ChessBoard
{

    internal class Board
    {
        public int Ranks { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; private set; }

        public Board() { }

        public Board(int ranks, int columns)
        {
            Ranks = ranks;
            Columns = columns;
            Pieces = new Piece[ranks, columns];
        }

        public void PutPiece(Piece p, Position pos)
        {
            Pieces[pos.Rank, pos.Column] = p;
            p.Position = pos;
        }
    }
}
