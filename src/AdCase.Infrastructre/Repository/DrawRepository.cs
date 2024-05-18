using AdCase.Domain.Entities;
using AdCase.Domain.Interfaces;
using AdCase.Infrastructre.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Infrastructre.Repository
{
    public class DrawRepository : RepositoryBase<Draw>, IDrawRepository
    {
        public DrawRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Group>> GetDrawedGroupsAsync()
        {
            var groups = await _context.Groups
                .Include(g => g.Teams)
                .ToListAsync();

            return groups.Select(g => new Group
            {
                GroupName = g.GroupName,
                Teams = g.Teams.Select(t => new Team { Name = t.Name }).ToList()
            }).ToList();
        }
    }
}
