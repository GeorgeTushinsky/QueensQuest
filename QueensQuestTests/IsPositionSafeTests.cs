using Xunit;
using QueensQuest;

namespace QueensQuestTests
{
    public class IsPositionSafeTests
    {
        [Fact]
        public void PositionNotSafe()
        {
            QueensSolver Solver = new QueensSolver(8);
            Solver[0, 0] = true;
            bool expectation = false;

            bool result = Solver.IsPositionSafe(0,8);

            Assert.Equal(expectation, result);
        }
    }
}
