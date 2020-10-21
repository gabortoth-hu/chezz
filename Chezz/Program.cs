using System;
using ChezzLib;
using ChezzLib.Pieces;

namespace Chezz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var table = new Table(8, 8);

            var pawn = new Pawn(PieceColor.White, table, new Position(2, 2));
            var pawn2 = new Pawn(PieceColor.Black, table, new Position(3, 3));
            var pawn3 = new Pawn(PieceColor.White, table, new Position(2, 3));
            
            var possibleMoves = pawn.GetPossibleMoves();

            foreach(var possibleMove in possibleMoves)
            {
                Console.WriteLine(possibleMove.To.ToString());
            }

        }
    }
}
