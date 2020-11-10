using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(color, 3)
        {

        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        /*public static List<Move> GetPossibleMoves(Table table, Position position)
        {
            var possibleMoves = new List<Move>();
            Position possiblePosition;

            // left up
            int file = position.File;
            int row = position.Row;
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

            return possibleMoves;
        }*/

        public override List<Move> GetPossibleMoves(Table table)
        {
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

            return possibleMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "B" : "b";
        }
    }
}
