using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Security;
using System.Text;
using System.Xml;

namespace ChezzLib
{
    public class GameEngine
    {

        //public static int Path



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
            foreach (var move in possibleMoves)
            {

                var value = EvaluatePath(table, move, color, depth);

                //if (value.Stuck != EvaluateResult.StuckType.NoStuck)
                //    return null;
                Console.WriteLine(move.ToString() + ": " + value.Value.ToString());


                if (bestMove == null || bestValue < value.Value)
                {
                    bestMove = move;
                    bestValue = value.Value;
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

        public class EvaluateResult {
            public enum StuckType
            {
                NoStuck,
                OpponentCantMove
            }

            public StuckType Stuck { get; set; }
            public int Value { get; set; }
        }

        public static EvaluateResult EvaluatePath(Table table, Move move, PieceColor color, int depth)
        {
            var table2 = (Table)table.Clone();
            table2.Move(move);

            if (depth == 0)
            {
                Move opponentsMove;
                opponentsMove = BestMoveByMaterialValue(table2, OpponentsColor(color));
                
                if (opponentsMove != null)
                    table2.Move(opponentsMove);

                return opponentsMove == null
                        ? new EvaluateResult() { Stuck = EvaluateResult.StuckType.OpponentCantMove, Value = ValueFor(table, color) }
                        : new EvaluateResult() { Value = ValueFor(table, color) };
            }
            else
            {

                var opponentsMaxValue = 0;
                Move opponentsBestMove = null;

                var opponentsPossibleMoves = table2.GetPossibleMoves(OpponentsColor(color));
                foreach (var opponentsPossibleMove in opponentsPossibleMoves)
                {
                    var opponentsValue = EvaluatePath(table2, opponentsPossibleMove, OpponentsColor(color), depth - 1);

                    if (opponentsBestMove == null || opponentsMaxValue < opponentsValue.Value)
                    {
                        opponentsBestMove = opponentsPossibleMove;
                        opponentsMaxValue = opponentsValue.Value;
                    }

                }

                return opponentsBestMove == null
                    ? new EvaluateResult() { Stuck = EvaluateResult.StuckType.OpponentCantMove, Value = opponentsMaxValue * -1 }
                    //: new EvaluateResult() { Value = MaterialValue((Table)table2.Clone(), color) };
                    : new EvaluateResult() { Value = opponentsMaxValue*-1 };
            }

        }

        public static Move BestMoveByMaterialValue(Table table, PieceColor color)
        {
            int maxValue = 0;
            Move bestMove = null;

            foreach (var move in table.GetPossibleMoves(color))
            {
                Table table2 = (Table)table.Clone();
                table2.Move(move);

                if(bestMove == null || table2.MaterialValue(color) > maxValue)
                {
                    maxValue = table2.MaterialValue(color);
                    bestMove = move;
                }
            }

            return bestMove;
        }

        private static int ValueFor(Table table, PieceColor color)
        {
            return color == PieceColor.White
                ? table.MaterialValue(PieceColor.White) - table.MaterialValue(PieceColor.Black)
                : table.MaterialValue(PieceColor.Black) - table.MaterialValue(PieceColor.White);
        }
    }
}
