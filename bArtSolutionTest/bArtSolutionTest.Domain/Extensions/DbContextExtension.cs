using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bArtSolutionTest.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace bArtSolutionTest.Domain.Extensions
{
    public static class DbContextExtension
    {
        private static DatabaseType CurrentDatabaseType { get; set; } = DatabaseType.SqlServer;
        public enum DatabaseType
        {
            SqlServer,
            MariaDb_MySql
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            if (CurrentDatabaseType == DatabaseType.MariaDb_MySql)
            {
                var connectionString = configuration.GetConnectionString("MySql");

                services.AddDbContext<RMPQAapiContext>(options =>
                      options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11)), x => x.MigrationsAssembly("bArtSolutionTest.Data")));
            }
            else if (CurrentDatabaseType == DatabaseType.SqlServer)
            {

                var connectionString = configuration.GetConnectionString("SqlServer");

                services.AddDbContext<RMPQAapiContext>(options =>
                      options.UseSqlServer(connectionString, x => x.MigrationsAssembly("bArtSolutionTest.Data")));
            }
            //...
        }
    }
}
