using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpTodoApp.Data;

/* This is used if database provider does't define
 * IAbpTodoAppDbSchemaMigrator implementation.
 */
public class NullAbpTodoAppDbSchemaMigrator : IAbpTodoAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
