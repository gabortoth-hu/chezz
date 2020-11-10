using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib
{
    public static class Helper
    {
        public static PieceColor OpponentsColor(PieceColor color)
        {
            return color == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }
    }
}
