using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor color) : base(color, 1)
        {
             
        }

        public override List<Move> GetPossibleMoves(Table table)
        {
            var possibleMoves = new List<Move>();

            if (Color == PieceColor.White && table.MaxRow > Position.Row
                || Color == PieceColor.Black && Position.Row > 1 )
            {
                int direction = Color == PieceColor.White ? 1 : -1;

                // forward
                var newPossiblePosition = new Position(Position.File, Position.Row + direction);
                if (table.GetPiece(newPossiblePosition) == null)
                    possibleMoves.Add(new Move(Position, newPossiblePosition));

                // capture left
                newPossiblePosition = new Position(Position.File - 1, Position.Row + direction);
                if (Position.File > 1
                    && table.GetPiece(newPossiblePosition) != null
                    && table.GetPiece(newPossiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, newPossiblePosition));
                }

                // capture right
                newPossiblePosition = new Position(Position.File + 1, Position.Row + direction);
                if (Position.File < table.MaxFile
                    && table.GetPiece(newPossiblePosition) != null
                    && table.GetPiece(newPossiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, newPossiblePosition));
                }
            }
            
            return possibleMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "P" : "p";
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        
    }
}
