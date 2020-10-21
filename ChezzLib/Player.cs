using ChezzLib.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChezzLib
{
    public class Player
    {
        public PieceColor Color { get;  }
        List<Piece> Pieces { get; set; }

        public Player(PieceColor color)
        {
            Color = color;
        }
    }
}
