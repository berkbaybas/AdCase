using AdCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Domain.Interfaces
{
    public interface ITeamRepository : IAsyncRepository<Team>
    {
    }
}
