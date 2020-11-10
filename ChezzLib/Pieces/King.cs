using System;
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
            var possibleMoves = new List<Move>();

            if(Position.File > 1)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 1, Position.Row), table, possibleMoves);
                /*possiblePosition = new Position(Position.File - 1, Position.Row);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.File < table.MaxFile)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 1, Position.Row), table, possibleMoves);
                /*possiblePosition = new Position(Position.File + 1, Position.Row);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.Row > 1)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File, Position.Row - 1), table, possibleMoves);
                /*possiblePosition = new Position(Position.File, Position.Row -1);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.Row < table.MaxRow)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File, Position.Row + 1), table, possibleMoves);
                /*possiblePosition = new Position(Position.File, Position.Row+1);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.File > 1 && Position.Row > 1)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 1, Position.Row - 1), table, possibleMoves);
                /*possiblePosition = new Position(Position.File - 1, Position.Row - 1);
                if(table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.File > 1 && Position.Row < table.MaxRow)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 1, Position.Row + 1), table, possibleMoves);
                /*possiblePosition = new Position(Position.File - 1, Position.Row + 1);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.File < table.MaxFile && Position.Row > 1)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 1, Position.Row - 1), table, possibleMoves);
                /*possiblePosition = new Position(Position.File + 1, Position.Row - 1);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            if (Position.File < table.MaxFile && Position.Row < table.MaxRow)
            {
                AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 1, Position.Row + 1), table, possibleMoves);
                /*possiblePosition = new Position(Position.File + 1, Position.Row + 1);
                if (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color)
                {
                    possibleMoves.Add(new Move(Position, possiblePosition));
                }*/
            }

            return possibleMoves;
        }


        public override string ToString()
        {
            return Color == PieceColor.White ? "I" : "i";
        }

    }
}
