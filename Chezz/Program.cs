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

            Console.Write(table.ToString());
            Console.ReadLine();

            while (table.CanMove(PieceColor.White) && table.CanMove(PieceColor.Black))
            {
                Console.WriteLine("Thinking...");
                var whiteMove = GameEngine.NextMove(table, PieceColor.White, 3);
                if (whiteMove != null)
                {
                    Console.WriteLine("White: " + whiteMove.ToString());
                    table.Move(whiteMove);
                    var blackMove = GameEngine.NextMove(table, PieceColor.Black, 3);
                    if (blackMove != null)
                    {
                        Console.WriteLine("Black: " + blackMove.ToString());
                        table.Move(blackMove);
                    }
                }
                Console.Write(table.ToString());
                Console.ReadLine();
            }

            Console.WriteLine("*** End of game ***");
            Console.ReadLine();

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
