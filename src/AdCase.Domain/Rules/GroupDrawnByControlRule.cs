using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Rules
{
    public class GroupDrawnByControlRule : Rule, IRule
    {
        public string Message => "You must enter a name who draw"; //TODO CHANGE CONST

        public GroupDrawnByControlRule()
        {
            NextRule = null; // if you need chain add class
        }

        public bool Run(LeagueRuleModel leagueRuleModel)
        {
            if (string.IsNullOrEmpty(leagueRuleModel.DrawnBy))
                return false;

            return true;
        }
    }
}
