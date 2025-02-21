using System.Threading.Tasks;

namespace AbpTodoApp.Data;

public interface IAbpTodoAppDbSchemaMigrator
{
    Task MigrateAsync();
}
