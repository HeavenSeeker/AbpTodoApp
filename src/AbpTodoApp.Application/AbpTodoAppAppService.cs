using AbpTodoApp.Localization;
using Volo.Abp.Application.Services;

namespace AbpTodoApp;

/* Inherit your application services from this class.
 */
public abstract class AbpTodoAppAppService : ApplicationService
{
    protected AbpTodoAppAppService()
    {
        LocalizationResource = typeof(AbpTodoAppResource);
    }
}
