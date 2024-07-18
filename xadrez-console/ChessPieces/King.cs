using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(BoardPosition pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Ranks, Board.Columns];

            BoardPosition position = new BoardPosition(0, 0);

            // Front
            position.DefineValues(Position.Rank - 1, Position.Column);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Front-left
            position.DefineValues(Position.Rank - 1, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Front-right
            position.DefineValues(Position.Rank - 1, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Back
            position.DefineValues(Position.Rank + 1, Position.Column);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Back-left
            position.DefineValues(Position.Rank + 1, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }
             
            // Back-right
            position.DefineValues(Position.Rank + 1, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Left
            position.DefineValues(Position.Rank, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Right
            position.DefineValues(Position.Rank, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            return matrix;
        }
    }
}
