using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ChezzLib
{
    public class Move : IEquatable<Move>
    {
        public Position From { get; }
        public Position To { get; }

        public Move (Position from, Position to)
        {
            From = from;
            To = to;
        }

        public bool Equals([AllowNull] Move other)
        {
            return From == other.From && To == other.To;
        }

        public override string ToString()
        {
            // itt will be way more sophisticated... it will need piece as well...
            return From.ToString() + To.ToString();
        }
    }
}
