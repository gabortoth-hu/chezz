using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ChezzLib
{
    public class Position : IEquatable<Position>
    {
        public Position(int file, int row)
        {
            File = file;
            Row = row;
        }

        public int Row { get; set; }
        public int File { get; set; }

        public bool Equals([AllowNull] Position other)
        {
            return Row.Equals(other.Row) && File.Equals(other.File);
        }

        public override int GetHashCode()
        {
            // don't like it...
            return 10*Row+File;
        }

        public override string ToString()
        {
            char[] abcArray = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();

            return abcArray[File - 1] + Row.ToString();
        }

        //public static Position operator +(Position p) => new Position(            ,1);
    }
}
