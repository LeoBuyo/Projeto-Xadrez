using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class King : Piece
    {

        private ChessMatch match;

        public King(Color color, Board board, ChessMatch match) : base(color, board)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(BoardPosition position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }

        private bool CastlingTest(BoardPosition position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.MovementCount == 0;
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

            // SpecialMove: Castling   
            if (MovementCount == 0 && !match.Check)
            {
                // Kingside
                BoardPosition KSRook = new BoardPosition(Position.Rank, Position.Column + 3);
                if (CastlingTest(KSRook))
                {
                    BoardPosition side1 = new BoardPosition(Position.Rank, Position.Column + 1);
                    BoardPosition side2 = new BoardPosition(Position.Rank, Position.Column + 2);
                    if (Board.Piece(side1) == null && Board.Piece(side2) == null)
                    {
                        matrix[Position.Rank, Position.Column + 2] = true;
                    }

                }
                // Queenside
                BoardPosition QSRook = new BoardPosition(Position.Rank, Position.Column - 4);
                if (CastlingTest(QSRook))
                {
                    BoardPosition side1 = new BoardPosition(Position.Rank, Position.Column - 1);
                    BoardPosition side2 = new BoardPosition(Position.Rank, Position.Column - 2);
                    BoardPosition side3 = new BoardPosition(Position.Rank, Position.Column - 3);
                    if (Board.Piece(side1) == null && Board.Piece(side2) == null && Board.Piece(side3) == null)
                    {
                        matrix[Position.Rank, Position.Column - 2] = true;
                    }

                }
            }
            return matrix;
        }
    }
}
