using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool EnemyInRange(BoardPosition pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool EmptyFront(BoardPosition pos)
        {
            return Board.piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Ranks, Board.Columns];

            BoardPosition position = new BoardPosition(0, 0);

            if (Color == Color.White)
            {
                position.DefineValues(Position.Rank - 1, Position.Column);
                if (Board.VerifyPosition(position) && EmptyFront(position))
                {
                    matrix[position.Rank, position.Column] = true;
                }
                position.DefineValues(Position.Rank - 2, Position.Column);
                if (Board.VerifyPosition(position) && EmptyFront(position) && MovementCount == 0)
                {
                    matrix[position.Rank, position.Column] = true;
                }
                position.DefineValues(Position.Rank - 1, Position.Column - 1);
                if (Board.VerifyPosition(position) && EnemyInRange(position))
                {
                    matrix[position.Rank, position.Column] = true;
                }
                position.DefineValues(Position.Rank - 1, Position.Column + 1);
                if (Board.VerifyPosition(position) && EnemyInRange(position))
                {
                    matrix[position.Rank, position.Column] = true;
                }
            }
            else
            {
                position.DefineValues(Position.Rank + 1, Position.Column);
                if (Board.VerifyPosition(position) && EmptyFront(position))
                {
                    matrix[position.Rank, position.Column] = true;
                }
                position.DefineValues(Position.Rank + 2, Position.Column);
                if (Board.VerifyPosition(position) && EmptyFront(position) && MovementCount == 0)
                {
                    matrix[position.Rank, position.Column] = true;
                }
                position.DefineValues(Position.Rank + 1, Position.Column - 1);
                if (Board.VerifyPosition(position) && EnemyInRange(position))
                {
                    matrix[position.Rank, position.Column] = true;
                }
                position.DefineValues(Position.Rank + 1, Position.Column + 1);
                if (Board.VerifyPosition(position) && EnemyInRange(position))
                {
                    matrix[position.Rank, position.Column] = true;
                }
            }

            return matrix;
        }
    }
}