using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Rook : Piece
    {
        public Rook(PieceColor color) : base(color, 5)
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
            return Color == PieceColor.White ? "R" : "r";
        }
    }
}
