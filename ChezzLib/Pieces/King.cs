using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class King : Piece
    {
        public King(PieceColor color) : base(color, 0)
        {

        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override List<Move> GetPossibleMoves(Table table)
        {
            throw new NotImplementedException();
        }


    }
}
