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
    }
}