using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Infra.Context;

namespace MovieApi.Infra.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieDbContext>(dbcontextoptions => dbcontextoptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            return services;
        }
    }
}