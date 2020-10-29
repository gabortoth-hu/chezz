using ChezzLib.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChezzLib
{
    /// <summary>
    /// Table is responsible for storing table dimesions and register pieces 
    /// Position is stored by pieces (I am not satisfied with this, it should
    /// stored in table class, but pieces should be identified somehow in this case,
    /// and it is not provided yet.)
    /// </summary>
    public class Table : ICloneable
    {
        public int MaxRow { get; set; }
        public int MaxFile { get; set; }

        private List<Piece> Pieces { get; set;  }

        

        public Table(int rows, int files)
        {
            MaxRow = rows;
            MaxFile = files;
            Pieces = new List<Piece>();

            Reset();
        }

        private void Reset()
        {
            
            for (int file = 1; file <= MaxFile; file++)
            {
                PutPiece(new Pawn(PieceColor.White), new Position(file,1));
                PutPiece(new Pawn(PieceColor.Black), new Position(file, MaxRow));
            }
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
                piece.Position = position;
                Pieces.Add(piece);   
            }
            else
            {
                throw new Exception("Cannot put piece: illegal position");
            }
        }

        public void Move(Move move)
        {
            //TODO: allow move for to the next color only

            var piece = GetPiece(move.From);
            if (piece == null)
                throw new Exception(String.Format("There is no piece in position {0}", move.From.ToString()));

            if(!piece.IsPossibleMove(move, this))
                throw new Exception(String.Format("Move {0} is not possible with this piece {1} ", move.ToString(), piece.ToString()));

            // handle capture
            move.Capture = GetPiece(move.To) != null;
            if(move.Capture)
            {
                Pieces.Remove(Pieces.First(x => x.Position.Equals(move.To)));
            }

            piece.Position = move.To;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int row = MaxRow; row >=1; row--) 
            {
                for (int file = 1; file <= MaxFile; file++)
                {
                    var p = GetPiece(new Position(file, row));
                    stringBuilder.Append(p == null ? " " : p.ToString());
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
            
        }

        public bool CanMove(PieceColor color)
        {
            return GetPossibleMoves(color).Count() > 0;
        }

        public int MaterialValue(PieceColor color)
        {
            return Pieces.Where(x => x.Color == color).Sum(x => x.Value);
        }
        
        public object Clone()
        {
            return new Table(this.MaxRow, this.MaxFile)
            {
                Pieces = this.Pieces.Select(piece => (Piece) piece.Clone()).ToList()
            };
        }

        public List<Move> GetPossibleMoves(PieceColor color)
        {
            return Pieces.Where(p => p.Color == color).SelectMany(p => p.GetPossibleMoves(this)).ToList();
        }
    }
}
