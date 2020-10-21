using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class King : Piece
    {
        public King(PieceColor color, Table table, Position position) : base(color, table, position)
        {

        }

        public override List<Move> GetPossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
