using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Rules
{
    public class Rule
    {
        public IRule NextRule { get; set; } = null!;
    }
}
