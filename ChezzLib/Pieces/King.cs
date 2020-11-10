﻿using System;
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
            return this.MemberwiseClone();
        }

        public override List<Move> GetPossibleMoves(Table table)
        {
            // TODO ...
            return new List<Move>();
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "I" : "i";
        }

    }
}
