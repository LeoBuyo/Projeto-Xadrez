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

        private bool CanMove(BoardPosition pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Ranks, Board.Columns];

            BoardPosition position = new BoardPosition(0, 0);

            // Front-left
            position.DefineValues(Position.Rank - 2, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Front-right
            position.DefineValues(Position.Rank - 2, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Back-left
            position.DefineValues(Position.Rank + 2, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Back-right
            position.DefineValues(Position.Rank + 2, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Left-up
            position.DefineValues(Position.Rank - 1, Position.Column - 2);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Left-down
            position.DefineValues(Position.Rank + 1, Position.Column - 2);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Right-up
            position.DefineValues(Position.Rank - 1, Position.Column + 2);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            // Right-down
            position.DefineValues(Position.Rank + 1, Position.Column + 2);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            return matrix;
        }
    }
}