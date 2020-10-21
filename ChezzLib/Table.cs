using ChezzLib.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChezzLib
{
    /// <summary>
    /// Table is responsible for storing table dimesions and register pieces 
    /// Position is stored by pieces (I am not satisfied with this, it should
    /// stored in table class, but pieces should be identified somehow in this case,
    /// and it is not provided yet.)
    /// </summary>
    public class Table
    {
        public int MaxRow { get; set; }
        public int MaxFile { get; set; }

        public List<Piece> Pieces { get; }

        public Table(int rows, int files)
        {
            MaxRow = rows;
            MaxFile = files;
            Pieces = new List<Piece>();
        }

        public Piece GetPiece(Position position)
        {
            return Pieces.Where(x => x.Position.Equals(position)).FirstOrDefault();
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (position.Row >= 1
                && position.Row <= MaxRow
                && position.File >= 1
                && position.File <= MaxFile
                && !Pieces.Any(x => x.Position.Equals(position)))
            {
                Pieces.Add(piece);   
            }
            else
            {
                throw new Exception("Cannot put piece: illegal position");
            }
        }

        public void Move(Move move)
        {
            var piece = GetPiece(move.From);
            if (piece == null)
                throw new Exception(String.Format("There is no piece in position {0}", move.From.ToString()));

            if(!piece.IsPossibleMove(move))
                throw new Exception(String.Format("Move {0} is not possible with this piece {1} ", move.ToString(), piece.ToString()));
        }
    }
}
