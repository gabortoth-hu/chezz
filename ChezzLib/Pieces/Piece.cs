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

        public Table Table { get; }

        // don't like: store should be stored in Table
        public Position Position { get; set; }

        /*public Piece(PieceColor Color, Table table)
        {
            this.Table = table;
            this.Color = Color;
            //this.Position = position;
            //stable.PutPiece(this, position);
        }*/

        protected Piece(PieceColor Color, Table table, int Value)
        {
            this.Table = table;
            this.Color = Color;
            this.Value = Value;
        }

        public abstract List<Move> GetPossibleMoves();

        public bool IsPossibleMove(Move move)
        {

            return GetPossibleMoves().Contains(move);
        }

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

        public abstract object Clone();
    }
}
