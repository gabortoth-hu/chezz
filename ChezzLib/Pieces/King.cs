using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class King : Piece
    {
        public King(PieceColor color, Table table) : base(color, table, 0)
        {

        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override List<Move> GetPossibleMoves()
        {
            throw new NotImplementedException();
        }


    }
}
