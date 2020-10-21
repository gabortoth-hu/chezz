using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ChezzLib.Pieces
{
    /// <summary>
    /// Base class of any other piece
    /// </summary>
    public abstract class Piece : IEquatable<Piece>
    {
        public PieceColor Color { get; set; }
        //public double Value { get; set; }

        public Table Table { get; }

        // don't like: store should be stored in Table
        public Position Position { get; }

        public Piece(PieceColor Color, Table table, Position position)
        {
            this.Table = table;
            this.Color = Color;
            this.Position = position;
            table.PutPiece(this, position);
        }

        public abstract List<Move> GetPossibleMoves();

        public bool Equals([AllowNull] Piece other)
        {
            return GetType() == other.GetType()
                && Color == other.Color
                && Table == other.Table
                && Position == other.Position;
        }

        public override int GetHashCode()
        {
            return new { Color, Table, Position }.GetHashCode();
        }
    }
}
