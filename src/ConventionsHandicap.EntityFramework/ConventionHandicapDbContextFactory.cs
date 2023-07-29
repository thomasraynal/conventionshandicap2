using Anabasis.Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ConventionsHandicap.Model;

namespace ConventionsHandicap.EntityFramework
{
    public class ConventionHandicapDbContextFactory : IDesignTimeDbContextFactory<ConventionHandicapDbContext>
    {

        public ConventionHandicapDbContext CreateDbContext(string[]? _)
        {

            var configuration = Configuration.GetAnabasisConfigurations();

            var conventionsHandicapConfiguration = new ConventionsHandicapConfigurationOptions();
            configuration.ConfigurationRoot.GetSection("conventionsHandicapConfigurationOptions").Bind(conventionsHandicapConfiguration);

            var optionsBuilder = new DbContextOptionsBuilder<ConventionHandicapDbContext>();

            optionsBuilder.UseSqlServer(conventionsHandicapConfiguration.SqlServerDbConnectionString);

            var dbContext = new ConventionHandicapDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}