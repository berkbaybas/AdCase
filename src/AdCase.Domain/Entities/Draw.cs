using AdCase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Entities
{
    public class Draw : BaseEntity
    {
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public string DrawnBy { get; set; }

    }
}
