using System;
using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;

namespace xadrez_console.ChessPieces
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color PlayerToAct { get; private set; }
        public bool Terminated { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlayerToAct = Color.White;
            InitialSetup();
        }

        public void ExecutionOfMovement(BoardPosition origin, BoardPosition destination)
        {
            Piece p = Board.TakePiece(origin);
            p.MovementCountIncrement();
            Piece CapturedPiece = Board.TakePiece(destination);
            Board.PutPiece(p, destination);
        }

        public void MakeMove(BoardPosition origin, BoardPosition destination)
        {
            ExecutionOfMovement(origin, destination);
            Turn++;
            ChangeTurn();
        }

        public void ValidateOriginPosition(BoardPosition position)
        {
            if (Board.piece(position) == null)
            {
                throw new ChessBoardException("There is no piece on the chosen origin!");
            }
            if (PlayerToAct != Board.piece(position).Color)
            {
                throw new ChessBoardException("Please select your own pieces!");
            }
            if (!Board.piece(position).ExistPossibleMovements())
            {
                throw new ChessBoardException("The piece have no possible movements!");
            }

        }

        public  void ValidateDestinationPosition(BoardPosition origin, BoardPosition destination)
        {
            if (!Board.piece(origin).CanMoveTo(destination))
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

        private void InitialSetup()
        {
            // Colocação das peças pretas
            Board.PutPiece(new Rook(Color.Black, Board), new PiecePosition('a', 8).ToPosition());
            Board.PutPiece(new Knight(Color.Black, Board), new PiecePosition('b', 8).ToPosition());
            Board.PutPiece(new Bishop(Color.Black, Board), new PiecePosition('c', 8).ToPosition());
            Board.PutPiece(new Queen(Color.Black, Board), new PiecePosition('d', 8).ToPosition());
            Board.PutPiece(new King(Color.Black, Board), new PiecePosition('e', 8).ToPosition());
            Board.PutPiece(new Bishop(Color.Black, Board), new PiecePosition('f', 8).ToPosition());
            Board.PutPiece(new Knight(Color.Black, Board), new PiecePosition('g', 8).ToPosition());
            Board.PutPiece(new Rook(Color.Black, Board), new PiecePosition('h', 8).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('a', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('b', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('c', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('d', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('e', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('f', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('g', 7).ToPosition());
            Board.PutPiece(new Pawn(Color.Black, Board), new PiecePosition('h', 7).ToPosition());

            // Colocação das peças brancas
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('a', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('b', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('c', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('d', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('e', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('f', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('g', 2).ToPosition());
            Board.PutPiece(new Pawn(Color.White, Board), new PiecePosition('h', 2).ToPosition());
            Board.PutPiece(new Rook(Color.White, Board), new PiecePosition('a', 1).ToPosition());
            Board.PutPiece(new Knight(Color.White, Board), new PiecePosition('b', 1).ToPosition());
            Board.PutPiece(new Bishop(Color.White, Board), new PiecePosition('c', 1).ToPosition());
            Board.PutPiece(new Queen(Color.White, Board), new PiecePosition('d', 1).ToPosition());
            Board.PutPiece(new King(Color.White, Board), new PiecePosition('e', 1).ToPosition());
            Board.PutPiece(new Bishop(Color.White, Board), new PiecePosition('f', 1).ToPosition());
            Board.PutPiece(new Knight(Color.White, Board), new PiecePosition('g', 1).ToPosition());
            Board.PutPiece(new Rook(Color.White, Board), new PiecePosition('h', 1).ToPosition());                  
        }
    }
}
