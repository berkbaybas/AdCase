using AdCase.Domain.Interfaces;
using AdCase.Infrastructre.Interceptors;
using AdCase.Infrastructre.Persistence;
using AdCase.Infrastructre.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdCase.Infrastructre
{
    public static class InfrastructreServiceRegistiration
    {
        public static IServiceCollection AddInfrastructreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("AdessoConnectionString")));

            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IDrawRepository, DrawRepository>();

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            return services;
        }

    }
}
