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
            var possibleMoves = new List<Move>();
            Position possiblePosition;

            // left
            int file = this.Position.File;
            do
            {
                file--;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file > 1 && table.GetPiece(possiblePosition) == null) ;

            // right
            file = this.Position.File;
            do
            {
                file++;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file < table.MaxFile && table.GetPiece(possiblePosition) == null);

            // down
            int row = this.Position.Row;
            do
            {
                row--;
                possiblePosition = new Position(this.Position.File, row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (row > 1 && table.GetPiece(possiblePosition) == null);

            // up
            row = this.Position.Row;
            do {
                row++;
                possiblePosition = new Position(this.Position.File, row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (row < table.MaxRow && table.GetPiece(possiblePosition) == null) ;

            return possibleMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "R" : "r";
        }
    }
}
