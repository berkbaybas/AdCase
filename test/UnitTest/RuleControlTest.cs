using AdCase.Domain.Helpers;
using AdCase.Domain.Rules;

namespace UnitTest
{
    public class RuleControlTest
    {
        // UnitOfWork_Condition_ExpectedResult
        [Fact]
        public void Rule_NotEqual4or8_Rejected()
        {

            // Arrange
            LeagueRuleModel lrm = new LeagueRuleModel { GroupCount = 3, DrawnBy = "berk"};

            // Action
            var (appResult, errMessage) = RuleHelper.CheckRules(lrm);

            // Assert
            Assert.False(appResult);
            Assert.Equal("Group size cannot be different 4 or 8", errMessage);
        }

        [Fact]
        public void Rule_ThereIsNoPersonWhoDraw_Rejected()
        {
            // Arrange
            LeagueRuleModel lrm = new LeagueRuleModel { GroupCount = 8 };

            // Action
            var (appResult, errMessage) = RuleHelper.CheckRules(lrm);

            // Assert
            Assert.False(appResult);
            Assert.Equal("You must enter a name who draw", errMessage);
        }

        [Fact]
        public void Rule_WithRequestedParameters_Success()
        {
            // Arrange
            LeagueRuleModel lrm = new LeagueRuleModel { GroupCount = 8, DrawnBy = "berk" };

            // Action
            var (appResult, errMessage) = RuleHelper.CheckRules(lrm);

            // Assert
            Assert.True(appResult);
        }
    }
}