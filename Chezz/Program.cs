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
            /*
            var pawn = new Pawn(PieceColor.White, table, new Position(2, 2));
            var pawn2 = new Pawn(PieceColor.Black, table, new Position(3, 3));
            var pawn3 = new Pawn(PieceColor.White, table, new Position(2, 3));
            
            var possibleMoves = pawn.GetPossibleMoves();

            foreach(var possibleMove in possibleMoves)
            {
                Console.WriteLine(possibleMove.To.ToString());
            }
            */

            while (table.CanMove(PieceColor.White) && table.CanMove(PieceColor.Black))
            {

            }

            /*
            table.Move(new Move(new Position(1, 1), new Position(1, 2)));
            Table table2 = (Table) table.Clone();
            table2.Move(new Move(new Position(1, 2), new Position(1, 3)));
            Console.Write(table.ToString());
            Console.WriteLine();
            Console.Write(table2.ToString());
            */
        }
    }
}
