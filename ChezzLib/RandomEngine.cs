using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChezzLib
{
    public class RandomEngine
    {
        protected Random Random { get; }
        public RandomEngine()
        {
            Random = new Random();
        }
        public Move NextMove(Table table, PieceColor color)
        {
            var moveList = table.GetPossibleMoves(color).ToList();
            return moveList.Count > 0 ? moveList[Random.Next(moveList.Count())] : null;

        }
    }
}
