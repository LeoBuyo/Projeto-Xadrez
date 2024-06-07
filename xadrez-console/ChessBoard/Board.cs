namespace xadrez_console.ChessBoard
{

    internal class Board
    {
        public int Ranks { get; set; }
        public int Columns { get; set; }
        public Piece[,] Piece { get; private set; }

        public Board() { }

        public Board(int ranks, int columns)
        {
            Ranks = ranks;
            Columns = columns;
            Piece = new Piece[ranks, columns];
        }
    }
}
