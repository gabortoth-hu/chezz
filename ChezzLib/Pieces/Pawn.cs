using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor color, Table table) : base(color, table, 1)
        {
             
        }

        public override List<Move> GetPossibleMoves()
        {
            var possibleMoves = new List<Move>();

            if (Color == PieceColor.White && Table.MaxRow > Position.Row
                || Color == PieceColor.Black && Position.Row > 1 )
            {
                int direction = Color == PieceColor.White ? 1 : -1;

                // forward
                var newPossiblePosition = new Position(Position.File, Position.Row + direction);
                if (Table.GetPiece(newPossiblePosition) == null)
                    possibleMoves.Add(new Move(Position, newPossiblePosition));

                // capture left
                newPossiblePosition = new Position(Position.File - 1, Position.Row + direction);
                if (Position.File > 1
                    && Table.GetPiece(newPossiblePosition) != null
                    && Table.GetPiece(newPossiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, newPossiblePosition));
                }

                // capture right
                newPossiblePosition = new Position(Position.File + 1, Position.Row + direction);
                if (Position.File < Table.MaxFile
                    && Table.GetPiece(newPossiblePosition) != null
                    && Table.GetPiece(newPossiblePosition).Color != Color)
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
