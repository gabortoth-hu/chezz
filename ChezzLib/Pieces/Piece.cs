using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ChezzLib.Pieces
{
    /// <summary>
    /// Base class of any other piece
    /// </summary>
    public abstract class Piece : IEquatable<Piece>, ICloneable
    {
        public PieceColor Color { get; set; }
        
        public int Value { get; }

        // don't like: store should be stored in Table
        public Position Position { get; set; }

        protected Piece(PieceColor Color, int Value)
        {
            //this.Table = table;
            this.Color = Color;
            this.Value = Value;
        }

        public abstract List<Move> GetPossibleMoves(Table table);

        public bool IsPossibleMove(Move move, Table table)
        {

            return GetPossibleMoves(table).Contains(move);
        }

        public bool Equals([AllowNull] Piece other)
        {
            return GetType() == other.GetType()
                && Color == other.Color
                //&& Table == other.Table
                && Position == other.Position;
        }

        public override int GetHashCode()
        {
            return new { Color, Position }.GetHashCode();
        }

        public abstract object Clone();

        protected void AddPossibleMoveIfEmptyOrOpponent(Position possiblePosition, Table table, List<Move> possibleMoves)
        {
            if (possiblePosition.Row >=1
                && possiblePosition.Row <= table.MaxRow
                && possiblePosition.File >= 1
                && possiblePosition.File <= table.MaxFile
                && (table.GetPiece(possiblePosition) == null
                    || table.GetPiece(possiblePosition).Color != Color))
            {
                possibleMoves.Add(new Move(Position, possiblePosition));
            }
        }
    }
}
