using System;
using System.Security.Cryptography.X509Certificates;
using xadrez_console.Board;
namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);

            Console.WriteLine("Position: " + p);

            Console.ReadLine();    
        }
    }
}
