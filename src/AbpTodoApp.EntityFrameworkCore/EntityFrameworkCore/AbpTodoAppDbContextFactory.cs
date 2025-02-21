using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpTodoApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpTodoAppDbContextFactory : IDesignTimeDbContextFactory<AbpTodoAppDbContext>
{
    public AbpTodoAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AbpTodoAppEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AbpTodoAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new AbpTodoAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpTodoApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
