using System;
using Xunit;
using QueensQuest;

namespace QueensQuestTests
{
    public class ChessMatrixSetup
    {
        public QueensSolver solver { get; set; }
        public ChessMatrixSetup()
        {
            solver = new QueensSolver(8);
        }
    }
    public class IsPositionSafeTests : IClassFixture<ChessMatrixSetup>
    {
        ChessMatrixSetup fixture;

        [Fact]
        public void TrueOutputExpected(ChessMatrixSetup fixture)
        {
            this.fixture = fixture;
            this.fixture.i
        }
    }
}
