﻿using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color PlayerToAct { get; private set; }
        public bool Terminated { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }
        public Piece VulnerableToEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerToAct = Color.White;
            Terminated = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            VulnerableToEnPassant = null;
            InitialSetup();
        }

        public Piece ExecutionOfMovement(BoardPosition origin, BoardPosition destination)
        {
            Piece p = Board.TakePiece(origin);
            p.MovementCountIncrease();
            Piece CapturedPiece = Board.TakePiece(destination);
            Board.PutPiece(p, destination);
            if (CapturedPiece != null)
            {
                Captured.Add(CapturedPiece);
            }

            // Kingside Castling
            if (p is King && destination.Column == origin.Column + 2)
            {
                BoardPosition originRook = new BoardPosition(origin.Rank, origin.Column + 3);
                BoardPosition destinationRook = new BoardPosition(origin.Rank, origin.Column + 1);
                Piece R = Board.TakePiece(originRook);
                R.MovementCountIncrease();
                Board.PutPiece(R, destinationRook);
            }

            // Queenside Castling
            if (p is King && destination.Column == origin.Column - 2)
            {
                BoardPosition originRook = new BoardPosition(origin.Rank, origin.Column - 4);
                BoardPosition destinationRook = new BoardPosition(origin.Rank, origin.Column - 1);
                Piece R = Board.TakePiece(originRook);
                R.MovementCountIncrease();
                Board.PutPiece(R, destinationRook);
            }

            // En Passant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && CapturedPiece == null)
                {
                    BoardPosition pawnPosition;
                    if (p.Color == Color.White)
                    {
                        pawnPosition = new BoardPosition(destination.Rank + 1, destination.Column);
                    }
                    else
                    {
                        pawnPosition = new BoardPosition(destination.Rank - 1, destination.Column);
                    }
                    CapturedPiece = Board.TakePiece(pawnPosition);
                    Captured.Add(CapturedPiece);
                }
            }

            return CapturedPiece;
        }

        public void UndoMovement(BoardPosition origin, BoardPosition destination, Piece capturedPiece)
        {
            Piece p = Board.TakePiece(destination);
            p.MovementCountDecrease();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }
            Board.PutPiece(p, origin);

            // Kingside Castling
            if (p is King && destination.Column == origin.Column + 2)
            {
                BoardPosition originRook = new BoardPosition(origin.Rank, origin.Column + 3);
                BoardPosition destinationRook = new BoardPosition(origin.Rank, origin.Column + 1);
                Piece R = Board.TakePiece(destinationRook);
                R.MovementCountDecrease();
                Board.PutPiece(R, originRook);
            }

            // Queenside Castling
            if (p is King && destination.Column == origin.Column - 2)
            {
                BoardPosition originRook = new BoardPosition(origin.Rank, destination.Column - 4);
                BoardPosition destinationRook = new BoardPosition(origin.Rank, destination.Column - 1);
                Piece R = Board.TakePiece(destinationRook);
                R.MovementCountDecrease();
                Board.PutPiece(R, originRook);
            }

            // En Passant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && capturedPiece == VulnerableToEnPassant)
                {
                    Piece pawn = Board.TakePiece(destination);
                    BoardPosition pawnPosition;
                    if (p.Color == Color.White)
                    {
                        pawnPosition = new BoardPosition(3, destination.Column);
                    }
                    else
                    {
                        pawnPosition = new BoardPosition(4, destination.Column);
                    }
                    Board.PutPiece(pawn, pawnPosition);
                }
            }
        }

        public void MakeMove(BoardPosition origin, BoardPosition destination)
        {
            Piece CapturedPiece = ExecutionOfMovement(origin, destination);

            if (IsInCheck(PlayerToAct))
            {
                UndoMovement(origin, destination, CapturedPiece);
                throw new ChessBoardException("Cannot put your king in check!");
            }

            Piece p = Board.Piece(destination);

            // SpecialMove: Promotion
            if (p is Pawn)
            {
                if ((p.Color == Color.White && destination.Rank == 0) || (p.Color == Color.Black && destination.Rank == 7))
                {
                    p = Board.TakePiece(destination);
                    Pieces.Remove(p);
                    Piece queen = new Queen(p.Color, Board);
                    Board.PutPiece(queen, destination);
                }
            }

            if (IsInCheck(Opponent(PlayerToAct)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (IsCheckmate(Opponent(PlayerToAct)))
            {
                Terminated = true;
            }
            else
            {
                Turn++;
                ChangeTurn();
            }

            // SpecialMove: En Passant 
            if (p is Pawn && (destination.Rank == origin.Rank - 2 || destination.Rank == origin.Rank + 2))
            {
                VulnerableToEnPassant = p;
            }
            else
            {
                VulnerableToEnPassant = null;
            }
        }

        public void ValidateOriginPosition(BoardPosition position)
        {
            if (Board.Piece(position) == null)
            {
                throw new ChessBoardException("There is no piece on the chosen origin!");
            }
            if (PlayerToAct != Board.Piece(position).Color)
            {
                throw new ChessBoardException("Please select your own pieces!");
            }
            if (!Board.Piece(position).ExistPossibleMovements())
            {
                throw new ChessBoardException("The piece have no possible movements!");
            }

        }

        public void ValidateDestinationPosition(BoardPosition origin, BoardPosition destination)
        {
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new ChessBoardException("Invalid destination position");
            }
        }

        private void ChangeTurn()
        {
            if (PlayerToAct == Color.White)
            {
                PlayerToAct = Color.Black;
            }
            else
            {
                PlayerToAct = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PieceInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PieceInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new ChessBoardException("There is no " + color + "king on the board!");
            }

            foreach (Piece x in PieceInGame(Opponent(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[K.Position.Rank, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PieceInGame(color))
            {
                bool[,] matrix = x.PossibleMovements();
                for (int i = 0; i < Board.Ranks; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            BoardPosition origin = x.Position;
                            BoardPosition destination = new BoardPosition(i, j);
                            Piece capturedPiece = ExecutionOfMovement(origin, destination);
                            bool isInCheck = IsInCheck(color);
                            UndoMovement(origin, destination, capturedPiece);
                            if (!isInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new PiecePosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void InitialSetup()
        {
            PutNewPiece('a', 8, new Rook(Color.Black, Board));
            PutNewPiece('b', 8, new Knight(Color.Black, Board));
            PutNewPiece('c', 8, new Bishop(Color.Black, Board));
            PutNewPiece('d', 8, new Queen(Color.Black, Board));
            PutNewPiece('e', 8, new King(Color.Black, Board, this));
            PutNewPiece('f', 8, new Bishop(Color.Black, Board));
            PutNewPiece('g', 8, new Knight(Color.Black, Board));
            PutNewPiece('h', 8, new Rook(Color.Black, Board));
            PutNewPiece('a', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('b', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('c', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('d', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('e', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('f', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('g', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('h', 7, new Pawn(Color.Black, Board, this));

            PutNewPiece('a', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('b', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('c', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('d', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('e', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('f', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('g', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('h', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('a', 1, new Rook(Color.White, Board));
            PutNewPiece('b', 1, new Knight(Color.White, Board));
            PutNewPiece('c', 1, new Bishop(Color.White, Board));
            PutNewPiece('d', 1, new Queen(Color.White, Board));
            PutNewPiece('e', 1, new King(Color.White, Board, this));
            PutNewPiece('f', 1, new Bishop(Color.White, Board));
            PutNewPiece('g', 1, new Knight(Color.White, Board));
            PutNewPiece('h', 1, new Rook(Color.White, Board));
        }
    }
}
