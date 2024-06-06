using System;
using xadrez_console.ChessBoard;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);

            Console.WriteLine("Position: " + p);

            Board board = new Board(8, 8);
        }
    }
}