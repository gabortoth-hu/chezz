using System;
using System.Text;
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

            RandomEngine randomEngine = new RandomEngine();

            Console.Write(table.ToString());
            Console.ReadLine();

            StringBuilder pgn = new StringBuilder();
            int i = 1;

            while (table.CanMove(PieceColor.White) && table.CanMove(PieceColor.Black))
            {
                Console.WriteLine("Thinking...");
                var whiteMove = GameEngine.NextMove(table, PieceColor.White, 4);
                if (whiteMove != null)
                {
                    Console.WriteLine("White: " + whiteMove.ToString());
                    table.Move(whiteMove); pgn.Append(i.ToString() + ". "); pgn.Append(whiteMove.ToString() + " "); 
                    Console.Write(table.ToString());

                    //var blackMove = GameEngine.NextMove(table, PieceColor.Black, 2);
                    var blackMove = randomEngine.NextMove(table, PieceColor.Black);
                    if (blackMove != null)
                    {
                        Console.WriteLine("Black: " + blackMove.ToString());
                        table.Move(blackMove); pgn.Append(blackMove.ToString() + " "); i++;
                        Console.Write(table.ToString());
                    }
                }
                
                //Console.ReadLine();
            }

            
            Console.WriteLine("*** End of game ***");
            Console.WriteLine(pgn.ToString());

        }
    }
}
