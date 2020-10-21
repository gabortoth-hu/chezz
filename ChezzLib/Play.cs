using System;
using System.Collections.Generic;
using System.Text;

namespace ChezzLib
{
    /// <summary>
    /// Record moves on a Table
    /// </summary>
    public class Play
    {
        public Table Table { get; }
        public List<Move> Moves { get; set; }

        public Play()
        {
            Table = new Table(8, 8);
        }
        public Play (Table Table)
        {
            this.Table = Table;
        }

        public void Move(Move move)
        {
            Table.Move(move);
            Moves.Add(move);
        }
    }
}
