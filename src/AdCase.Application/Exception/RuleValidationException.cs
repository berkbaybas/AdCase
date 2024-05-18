using AdCase.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Application.Exception
{
    public class RuleValidationException : System.Exception
    {
        public string Message { get; } = null!;

        public RuleValidationException(IRule fault)
        {
            this.Message = fault.Message;
        }

        public override string ToString()
        {
            // TODO CAN BE LOG
            return $"{Message}";
        }
    }
}
