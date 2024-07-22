using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class Pawn : Piece
    {
        private ChessMatch match;

        public Pawn(Color color, Board board, ChessMatch match) : base(color, board)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool EnemyInRange(BoardPosition pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool EmptyFront(BoardPosition pos)
        {
            return Board.Piece(pos) == null;
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


                // SpecialMove: En Passant
                if ( Position.Rank == 3)
                {
                    BoardPosition left = new BoardPosition(Position.Rank, Position.Column - 1);
                    if (Board.VerifyPosition(left) && EnemyInRange(left) && Board.Piece(left) == match.VulnerableToEnPassant)
                    {
                        matrix[left.Rank - 1, left.Column] = true;
                    }
                }
                if (Position.Rank == 3)
                {
                    BoardPosition right = new BoardPosition(Position.Rank, Position.Column + 1);
                    if (Board.VerifyPosition(right) && EnemyInRange(right) && Board.Piece(right) == match.VulnerableToEnPassant)
                    {
                        matrix[right.Rank - 1, right.Column] = true;
                    }
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

                // SpecialMove: En Passant
                if (Position.Rank == 4)
                {
                    BoardPosition left = new BoardPosition(Position.Rank, Position.Column - 1);
                    if (Board.VerifyPosition(left) && EnemyInRange(left) && Board.Piece(left) == match.VulnerableToEnPassant)
                    {
                        matrix[left.Rank + 1, left.Column] = true;
                    }
                }
                if (Position.Rank == 4)
                {
                    BoardPosition right = new BoardPosition(Position.Rank, Position.Column + 1);
                    if (Board.VerifyPosition(right) && EnemyInRange(right) && Board.Piece(right) == match.VulnerableToEnPassant)
                    {
                        matrix[right.Rank + 1, right.Column] = true;
                    }
                }
            }

            return matrix;
        }
    }
}