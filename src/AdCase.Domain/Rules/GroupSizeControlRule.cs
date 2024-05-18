using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Rules
{
    public class GroupSizeControlRule : Rule, IRule
    {
        public string Message => "Group size cannot be different 4 or 8"; // TODO CHANGE CONST

        public GroupSizeControlRule()
        {
              NextRule = new GroupDrawnByControlRule(); // if you need chain add class
        }

        public bool Run(LeagueRuleModel leagueRuleModel)
        {
            if (leagueRuleModel.GroupCount == 4 || leagueRuleModel.GroupCount == 8)
                return true;

            return false;
        }
    }
}
