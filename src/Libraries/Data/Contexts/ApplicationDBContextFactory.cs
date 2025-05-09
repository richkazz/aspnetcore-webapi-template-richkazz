using System.IO;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        bool isOnline = false;
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(@Directory.GetCurrentDirectory() + "/../../Presentations/WebApi/appsettings.Development.json").Build();
        var connectionString = isOnline ? configuration.GetConnectionString("DefaultConnection") : configuration.GetConnectionString("DefaultConnection");

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseSqlServer(connectionString);
        return new ApplicationDbContext(builder.Options);
    }
}