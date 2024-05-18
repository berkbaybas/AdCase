using AdCase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
