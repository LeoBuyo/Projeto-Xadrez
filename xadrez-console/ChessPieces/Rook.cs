﻿using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(BoardPosition pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Ranks, Board.Columns];

            BoardPosition position = new BoardPosition(0, 0);

            // Front
            position.DefineValues(Position.Rank - 1, Position.Column);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Rank = position.Rank - 1;
            }

            // Back
            position.DefineValues(Position.Rank + 1, Position.Column);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Rank = position.Rank + 1;
            }

            // Right
            position.DefineValues(Position.Rank, Position.Column + 1);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            // Left
            position.DefineValues(Position.Rank, Position.Column - 1);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }
            return matrix;
        }
    }
}