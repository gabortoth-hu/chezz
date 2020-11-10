using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Queen : Piece
    {
        public Queen(PieceColor color): base(color, 9)
        {

        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override List<Move> GetPossibleMoves(Table table)
        {
            // "bishop moves" 
            var possibleMoves = new List<Move>();
            Position possiblePosition;

            // left up
            int file = Position.File;
            int row = Position.Row;
            do
            {
                file--;
                row++;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file > 1 && row < table.MaxRow && table.GetPiece(possiblePosition) == null);

            // right up
            file = Position.File;
            row = Position.Row;
            do
            {
                file++;
                row++;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file < table.MaxFile && row < table.MaxRow && table.GetPiece(possiblePosition) == null);

            // left down
            file = Position.File;
            row = Position.Row;
            do
            {
                file--;
                row--;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file > 1 && row > 1 && table.GetPiece(possiblePosition) == null);

            // right down
            file = Position.File;
            row = Position.Row;
            do
            {
                file++;
                row--;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file < table.MaxFile && row > 1 && table.GetPiece(possiblePosition) == null);

            // "rook" moves

            // left
            file = this.Position.File;
            do
            {
                file--;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file > 1 && table.GetPiece(possiblePosition) == null);

            // right
            file = this.Position.File;
            do
            {
                file++;
                possiblePosition = new Position(file, this.Position.Row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (file < table.MaxFile && table.GetPiece(possiblePosition) == null);

            // down
            row = this.Position.Row;
            do
            {
                row--;
                possiblePosition = new Position(this.Position.File, row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (row > 1 && table.GetPiece(possiblePosition) == null);

            // up
            row = this.Position.Row;
            do
            {
                row++;
                possiblePosition = new Position(this.Position.File, row);
                AddPossibleMoveIfEmptyOrOpponent(possiblePosition, table, possibleMoves);
            } while (row < table.MaxRow && table.GetPiece(possiblePosition) == null);

            return possibleMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "Q" : "q";
        }
    }
}
