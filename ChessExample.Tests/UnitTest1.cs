namespace ChessExample.Tests
{
    public class CheckerBoardPositionTests
    {
        [Fact]
        public void ConstructorValidCoordinatesSuccess()
        {
            var pos = new CheckerBoardPosition(1, 1);

            Assert.Equal(1, pos.X);
            Assert.Equal(1, pos.Y);
        }

        [Fact]
        public void ConstructorInvalidXThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new CheckerBoardPosition(0, 1));
        }

        [Fact]
        public void ConstructorInvalidYThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new CheckerBoardPosition(1, 9));
        }

        [Fact]
        public void XLetterReturnsCorrectLetter()
        {
            var pos = new CheckerBoardPosition(1, 5);

            Assert.Equal('A', pos.XLetter);
        }

        [Fact]
        public void XLetterHColumnReturnsH()
        {
            var pos = new CheckerBoardPosition(8, 1);

            Assert.Equal('H', pos.XLetter);
        }

        [Fact]
        public void ToStringReturnsChessNotation()
        {
            var pos = new CheckerBoardPosition(5, 2);

            var result = pos.ToString();

            Assert.Equal("E2", result);
        }

        [Theory]
        [InlineData("A1", 1, 1)]
        [InlineData("E2", 5, 2)]
        [InlineData("H8", 8, 8)]
        public void TryParseValidInputReturnsTrue(string input, byte x, byte y)
        {
            var success = CheckerBoardPosition.TryParse(input, null, out var result);

            Assert.True(success);
            Assert.NotNull(result);
            Assert.Equal(x, result.X);
            Assert.Equal(y, result.Y);
        }

        [Theory]
        [InlineData("Z9")]
        [InlineData("A9")]
        [InlineData("I1")]
        [InlineData("AA")]
        [InlineData("")]
        public void TryParseInvalidInputReturnsFalse(string input)
        {
            var success = CheckerBoardPosition.TryParse(input, null, out var result);

            Assert.False(success);
            Assert.Null(result);
        }

        [Fact]
        public void TryParseNullReturnsFalse()
        {
            var success = CheckerBoardPosition.TryParse(null, null, out var result);

            Assert.False(success);
            Assert.Null(result);
        }

        [Fact]
        public void ParsInvalidInputThrowsException()
        {
            Assert.Throws<FormatException>(() =>
                CheckerBoardPosition.Parse("Z9", null));
        }

        [Fact]
        public void ParseValidInputReturnsPosition()
        {
            var pos = CheckerBoardPosition.Parse("E2", null);

            Assert.Equal(5, pos.X);
            Assert.Equal(2, pos.Y);
        }
    }

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