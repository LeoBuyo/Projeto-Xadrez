using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
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

            // Front-left
            position.DefineValues(Position.Rank - 1, Position.Column - 1);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Rank = position.Rank - 1;
                position.Column = position.Column - 1;
            }

            // Front-right
            position.DefineValues(Position.Rank - 1, Position.Column + 1);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Rank = position.Rank - 1;
                position.Column = position.Column + 1;
            }

            // Back-left
            position.DefineValues(Position.Rank + 1, Position.Column - 1);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Rank = position.Rank + 1;
                position.Column = position.Column - 1;
            }

            // Back-right
            position.DefineValues(Position.Rank + 1, Position.Column + 1);
            while (Board.VerifyPosition(position) && CanMove(position))
            {
                matrix[position.Rank, position.Column] = true;
                if (Board.piece(position) != null && Board.piece(position).Color != Color)
                {
                    break;
                }
                position.Rank = position.Rank + 1;
                position.Column = position.Column + 1;
            }

            return matrix;
        }
    }
}