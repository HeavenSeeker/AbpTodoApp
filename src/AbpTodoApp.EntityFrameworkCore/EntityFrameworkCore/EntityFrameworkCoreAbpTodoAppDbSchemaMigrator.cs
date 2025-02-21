using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpTodoApp.Data;
using Volo.Abp.DependencyInjection;

namespace AbpTodoApp.EntityFrameworkCore;

public class EntityFrameworkCoreAbpTodoAppDbSchemaMigrator
    : IAbpTodoAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpTodoAppDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpTodoAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpTodoAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
