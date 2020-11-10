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

            //Reset();
        }

        public void Reset()
        {

            // pawns
            for (int file = 1; file <= MaxFile; file++)
            {
                //PutPiece(new Pawn(PieceColor.White), new Position(file, 1));
                PutPiece(new Pawn(PieceColor.White), new Position(file, 2));
                PutPiece(new Pawn(PieceColor.Black), new Position(file, MaxRow-1));
                //PutPiece(new Pawn(PieceColor.Black), new Position(file, MaxRow));
            }

            // Rooks
            PutPiece(new Rook(PieceColor.White), new Position(1, 1));
            PutPiece(new Rook(PieceColor.White), new Position(8, 1));
            PutPiece(new Rook(PieceColor.Black), new Position(1, 8));
            PutPiece(new Rook(PieceColor.Black), new Position(8, 8));

            // Knights
            PutPiece(new Knight(PieceColor.White), new Position(2, 1));
            PutPiece(new Knight(PieceColor.White), new Position(7, 1));
            PutPiece(new Knight(PieceColor.Black), new Position(2, 8));
            PutPiece(new Knight(PieceColor.Black), new Position(7, 8));

            //Bishops
            PutPiece(new Bishop(PieceColor.White), new Position(3, 1));
            PutPiece(new Bishop(PieceColor.White), new Position(6, 1));
            PutPiece(new Bishop(PieceColor.Black), new Position(3, 8));
            PutPiece(new Bishop(PieceColor.Black), new Position(6, 8));

            // Queens
            PutPiece(new Queen(PieceColor.White), new Position(4, 1));
            PutPiece(new Queen(PieceColor.Black), new Position(4, 8));

            // Kings
            PutPiece(new King(PieceColor.White), new Position(5, 1));
            PutPiece(new King(PieceColor.Black), new Position(5, 8));
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

        public bool IsInCheck(PieceColor color)
        {
            var king = Pieces.First(x => x.Color == color && x.GetType() == typeof(King));
            
            var opponentsPossibleMoves = GetPossibleMoves(Helper.OpponentsColor(color));

            return opponentsPossibleMoves.Any(x => x.To.Equals(king.Position));
        }

        public bool IsCheck(Move move)
        {
            var color = Pieces.First(x => x.Position.Equals(move.From)).Color;
            var table2 = (Table)Clone();
            table2.Move(move);
            return IsInCheck(color);
        }
    }
}
