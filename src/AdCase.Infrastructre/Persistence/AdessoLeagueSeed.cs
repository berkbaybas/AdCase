using AdCase.Domain.Entities;
using AdCase.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Infrastructre.Persistence
{
    public sealed class AdessoLeagueSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, ILogger<AdessoLeagueSeed> logger)
        {
            if (!context.Teams.Any())
            {
                context.Teams.AddRange(GetPreconfiguredTeams());

                await context.SaveChangesAsync();

                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationException).Name);
            }
        }

        private static IEnumerable<Team> GetPreconfiguredTeams()
        {
            return TeamHelper.GetAllTeams();
        }
    }
}
