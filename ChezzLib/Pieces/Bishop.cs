using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(color, 3)
        {

        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override List<Move> GetPossibleMoves(Table table)
        {
            // TODO ...
            return new List<Move>();
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "B" : "b";
        }
    }
}
