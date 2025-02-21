using AbpTodoApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpTodoApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpTodoAppEntityFrameworkCoreModule),
    typeof(AbpTodoAppApplicationContractsModule)
)]
public class AbpTodoAppDbMigratorModule : AbpModule
{
}
