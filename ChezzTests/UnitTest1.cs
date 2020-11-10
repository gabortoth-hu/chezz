using ChezzLib;
using ChezzLib.Pieces;
using NUnit.Framework;

namespace ChezzTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RookCheck()
        {
            Table table = new Table(8,8);
            table.PutPiece(new Pawn(PieceColor.Black), new Position(4, 4));
            table.PutPiece(new King(PieceColor.White), new Position(3,3));
            Assert.IsTrue(table.IsInCheck(PieceColor.White));
        }

        [Test]
        public void NotInCheck()
        {
            Table table = new Table(8, 8);
            table.PutPiece(new Pawn(PieceColor.Black), new Position(4, 4));
            table.PutPiece(new King(PieceColor.White), new Position(4, 3));
            Assert.IsFalse(table.IsInCheck(PieceColor.White));
        }

        [Test]
        public void InCheck()
        {
            Table table = new Table(8, 8);
            table.PutPiece(new Pawn(PieceColor.Black), new Position(4, 4));
            table.PutPiece(new King(PieceColor.White), new Position(4, 3));
            Assert.IsTrue(table.IsCheck(new Move(new Position(4,3), new Position(3,3))));
        }
    }
}