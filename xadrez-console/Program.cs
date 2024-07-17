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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        BoardPosition origin = Screen.ReadPiecePosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possibleMovements = match.Board.piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possibleMovements);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        BoardPosition destination = Screen.ReadPiecePosition().ToPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.MakeMove(origin, destination);
                    }
                    catch (ChessBoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}