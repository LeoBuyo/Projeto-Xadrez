using System;
using xadrez_console.ChessBoard;
using xadrez_console.ChessBoard.Enums;
using xadrez_console.ChessPieces;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Terminated)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    BoardPosition origin = Screen.ReadPiecePosition().ToPosition();

                    bool[,] possibleMovements = match.Board.piece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possibleMovements);

                    Console.Write("Destination: ");
                    BoardPosition destination = Screen.ReadPiecePosition().ToPosition();

                    match.ExecutionOfMovement(origin, destination);
                }
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}