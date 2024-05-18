using AdCase.Domain.Entities;
using AdCase.Domain.Interfaces;
using AdCase.Infrastructre.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Infrastructre.Repository
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
