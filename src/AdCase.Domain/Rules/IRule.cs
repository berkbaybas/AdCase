using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Rules
{
    public interface IRule
    {
        bool Run(LeagueRuleModel leagueRuleModel);
        IRule NextRule { get; set; }
        public string Message { get; }
    }
}
