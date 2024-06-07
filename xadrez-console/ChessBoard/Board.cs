﻿namespace xadrez_console.ChessBoard
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

        public Piece piece(Position pos)
        {
            return Pieces[pos.Rank, pos.Column];
        }

        public bool PieceExist(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (PieceExist(pos))
            {
                throw new ChessBoardException("There's already a piece in that position!");
            }
            Pieces[pos.Rank, pos.Column] = p;
            p.Position = pos;
        }

        public bool VerifyPosition(Position pos)
        {
            if (pos.Rank < 0 || pos.Column < 0 || pos.Rank >= Ranks || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!VerifyPosition(pos))
            {
                throw new ChessBoardException("Invalid Position!");
            }
        }
    }
}
