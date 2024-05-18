using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.DTO
{
    public class GroupDto
    {
        public string GroupName { get; set; }
        public List<string> Teams { get; set; }
    }
}
