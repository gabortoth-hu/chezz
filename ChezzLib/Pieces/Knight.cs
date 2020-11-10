using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor color) : base(color, 3)
        {

        }
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override List<Move> GetPossibleMoves(Table table)
        {
            var possibleMoves = new List<Move>();

            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 2, Position.Row - 1), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 2, Position.Row + 1), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 1, Position.Row - 2), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File - 1, Position.Row + 2), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 2, Position.Row - 1), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 2, Position.Row + 1), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 1, Position.Row - 2), table, possibleMoves);
            AddPossibleMoveIfEmptyOrOpponent(new Position(Position.File + 1, Position.Row + 2), table, possibleMoves);

            return possibleMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "K" : "k";
        }
    }
}
