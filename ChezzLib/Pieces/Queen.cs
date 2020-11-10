using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Queen : Piece
    {
        public Queen(PieceColor color): base(color, 9)
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
            return Color == PieceColor.White ? "Q" : "q";
        }
    }
}
