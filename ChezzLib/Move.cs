﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ChezzLib
{
    public class Move : IEquatable<Move>
    {
        public Position From { get; }
        public Position To { get; }

        public bool Capture { get; set; }
        // other moves:
        // https://en.wikipedia.org/wiki/Algebraic_notation_(chess)

        public Move (Position from, Position to)
        {
            From = from;
            To = to;
        }

        public bool Equals([AllowNull] Move other)
        {
            return From.Equals(other.From) && To.Equals(other.To);
        }

        public override string ToString()
        {
            // itt will be way more sophisticated... it will need piece as well...
            return From.ToString() 
                + (Capture ? "x" : "")
                + To.ToString();
        }

        public override int GetHashCode()
        {
            // ...
            return 1000 * From.File + 100 * From.Row + 10 * To.File + To.Row;
        }
    }
}
