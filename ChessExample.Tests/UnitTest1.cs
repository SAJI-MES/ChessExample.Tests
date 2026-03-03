namespace ChessExample.Tests
{
    public class ChessFiguresTests
    {
        [Fact]
        public void RookValidMove()
        {
            var rook = new Rook();
            var from = new CheckerBoardPosition(1, 1);
            var to = new CheckerBoardPosition(1, 8);

            Assert.True(rook.IsValidMove(from, to));
        }

        [Fact]
        public void RookInvalidMove()
        {
            var rook = new Rook();
            var from = new CheckerBoardPosition(1, 1);
            var to = new CheckerBoardPosition(3, 3);

            Assert.False(rook.IsValidMove(from, to));
        }

        [Fact]
        public void BishopValidMove()
        {
            var bishop = new Bishop();
            var from = new CheckerBoardPosition(3, 3);
            var to = new CheckerBoardPosition(6, 6);

            Assert.True(bishop.IsValidMove(from, to));
        }

        [Fact]
        public void BishopInvalidMove()
        {
            var bishop = new Bishop();
            var from = new CheckerBoardPosition(3, 3);
            var to = new CheckerBoardPosition(3, 6);

            Assert.False(bishop.IsValidMove(from, to));
        }

        [Fact]
        public void QueenValidDiagonalMove()
        {
            var queen = new Queen();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(6, 6);

            Assert.True(queen.IsValidMove(from, to));
        }

        [Fact]
        public void QueenInvalidMove()
        {
            var queen = new Queen();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(5, 6);

            Assert.False(queen.IsValidMove(from, to));
        }

        [Fact]
        public void KnightValidMoveType1()
        {
            var knight = new Knight();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(5, 6);

            Assert.True(knight.IsValidMove(from, to));
        }

        [Fact]
        public void KnightValidMoveType2()
        {
            var knight = new Knight();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(6, 5);

            Assert.True(knight.IsValidMove(from, to));
        }

        [Fact]
        public void Knight_InvalidMove()
        {
            var knight = new Knight();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(4, 6);

            Assert.False(knight.IsValidMove(from, to));
        }

        [Fact]
        public void KingValidMove()
        {
            var king = new King();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(5, 5);

            Assert.True(king.IsValidMove(from, to));
        }

        [Fact]
        public void KingInvalidMove()
        {
            var king = new King();
            var from = new CheckerBoardPosition(4, 4);
            var to = new CheckerBoardPosition(6, 4);

            Assert.False(king.IsValidMove(from, to));
        }
    }
}