using AdCase.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Helpers
{
    public static class RuleHelper
    {
        public static (bool,string) CheckRules(LeagueRuleModel leagueRuleModel)
        {
            IRule firstRule = new GroupSizeControlRule();
            while (firstRule.NextRule != null) //Next Rule bitene kadar dön
            {
                if (firstRule.Run(leagueRuleModel))
                {
                    firstRule = firstRule.NextRule;
                }
                else
                {
                    return (false, firstRule.Message);
                }
            }
            if (firstRule.NextRule == null) // Working Tail Rule Process(run last rule)
            {
                if (firstRule.Run(leagueRuleModel) == false)
                {
                    return (false, firstRule.Message);
                }
            }

            return (true, "");
        }
    }
}
