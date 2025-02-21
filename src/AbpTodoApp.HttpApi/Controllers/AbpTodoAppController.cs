using AbpTodoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpTodoApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpTodoAppController : AbpControllerBase
{
    protected AbpTodoAppController()
    {
        LocalizationResource = typeof(AbpTodoAppResource);
    }
}
