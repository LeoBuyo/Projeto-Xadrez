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

            //front
            position.defineValues(Position.Rank - 1, Position.Column);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //front-left
            position.defineValues(Position.Rank - 1, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //front-right
            position.defineValues(Position.Rank - 1, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //back
            position.defineValues(Position.Rank + 1, Position.Column);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //back-left
            position.defineValues(Position.Rank + 1, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //back-right
            position.defineValues(Position.Rank + 1, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //right
            position.defineValues(Position.Rank, Position.Column + 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }

            //left
            position.defineValues(Position.Rank, Position.Column - 1);
            if (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
            }
            return matrix;
        }
    }
}
