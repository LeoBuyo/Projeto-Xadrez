using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessBoard
{
    internal abstract class Piece
    {
        public BoardPosition Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementCount { get; protected set; }
        public Board Board { get; protected set; }
        public Piece() { }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            MovementCount = 0;
            Board = board;
        }

        public abstract bool[,] PossibleMovements();

        public bool ExistPossibleMovements()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < Board.Ranks; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(BoardPosition position)
        {
            return PossibleMovements()[position.Rank, position.Column];
        }

        public void MovementCountIncrease()
        {
            MovementCount++;
        }

        public void MovementCountDecrease()
        {
            MovementCount--;
        }
    }
}
