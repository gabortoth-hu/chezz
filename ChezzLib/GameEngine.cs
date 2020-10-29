using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;
using System.Xml;

namespace ChezzLib
{
    public class GameEngine
    {
        /// <summary>
        /// Next 'best' move for Color on a given table.
        /// (Suppose that next 'move' is for given color on the given table)
        /// </summary>
        /// <param name="table"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Move NextMove(Table table, PieceColor color, int depth)
        {
            // get possible moves for color
            var possibleMoves = table.GetPossibleMoves(color);
            Move bestMove = null;
            int bestValue = 0;

            // evaluate all moves
            foreach(var move in possibleMoves)
            {
                //Console.WriteLine("Depth: " + depth.ToString());

                // given color's move
                Table table2 = (Table)table.Clone();
                table2.Move(move);

                // opponent's move
                Move opponentsMove = null;
                if (depth > 0)
                {
                    opponentsMove = NextMove(table2, OpponentsColor(color), depth - 1);
                }
                else
                {
                    Move opponentsBestMove = null;
                    int opponentsBestValue = 0;
                    foreach(var move2 in table2.GetPossibleMoves(OpponentsColor(color)))
                    {
                        Table table3 = (Table)table2.Clone();
                        table3.Move(move2);

                        if(opponentsBestMove == null ||opponentsBestValue < table3.MaterialValue(OpponentsColor(color)))
                        {
                            opponentsMove = move2;
                            opponentsBestValue = table3.MaterialValue(OpponentsColor(color));
                        }
                    }
                }
                
                if(opponentsMove != null)
                    table2.Move(opponentsMove);

                if(bestMove == null || bestValue < table2.MaterialValue(color))
                {
                    bestMove = move;
                    bestValue = table2.MaterialValue(color);
                }

            }

            return bestMove;
        }

        public static PieceColor OpponentsColor(PieceColor color)
        {
            return color == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }

        /// <summary>
        /// Get MaterialValue for color
        /// </summary>
        /// <param name="table"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int MaterialValue(Table table, PieceColor color)
        {
            return table.MaterialValue(color) - table.MaterialValue(color == PieceColor.White ? PieceColor.Black : PieceColor.White);
        }

        public static int EvaluatePath(Table table, PieceColor color, int maxDepth)
        {
            if(maxDepth == 0)
            {
                return ValueFor(table, color);
            }

            return EvaluatePath(table, color, maxDepth - 1);
        }

        private static int ValueFor(Table table, PieceColor color)
        {
            return color == PieceColor.White
                ? table.MaterialValue(PieceColor.White) - table.MaterialValue(PieceColor.Black)
                : table.MaterialValue(PieceColor.Black) - table.MaterialValue(PieceColor.White);
        }
    }
}
