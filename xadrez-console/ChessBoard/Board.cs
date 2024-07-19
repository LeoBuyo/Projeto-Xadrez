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

        public Piece Piece(BoardPosition position)
        {
            return Pieces[position.Rank, position.Column];
        }

        public bool PieceExist(BoardPosition pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PutPiece(Piece p, BoardPosition pos)
        {
            if (PieceExist(pos))
            {
                throw new ChessBoardException("There's already a piece in that position!");
            }
            Pieces[pos.Rank, pos.Column] = p;
            p.Position = pos;
        }

        public Piece TakePiece(BoardPosition pos)
        {
            if (Piece(pos) == null)
            {
                return null;
            }
            Piece temp = Piece(pos);
            temp.Position = null;
            Pieces[pos.Rank, pos.Column] = null;
            return temp;
        }

        public bool VerifyPosition(BoardPosition pos)
        {
            if (pos.Rank < 0 || pos.Column < 0 || pos.Rank >= Ranks || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(BoardPosition pos)
        {
            if (!VerifyPosition(pos))
            {
                throw new ChessBoardException("Invalid Position!");
            }
        }
    }
}
