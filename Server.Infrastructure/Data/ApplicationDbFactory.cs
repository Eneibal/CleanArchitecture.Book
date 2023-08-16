using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Server.Infrastructure.Data;
public class ApplicationDbFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        const string patch = "./Configurations/appsetings.json";
        const string connectionName = "MainConnectionString";

        var config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile(patch)
                   .Build();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(config.GetConnectionString(connectionName))
                    .Options;

        return new ApplicationDbContext(options);
    }
}
