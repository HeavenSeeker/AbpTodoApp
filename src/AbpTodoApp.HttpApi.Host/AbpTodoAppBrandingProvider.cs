using Microsoft.Extensions.Localization;
using AbpTodoApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpTodoApp;

[Dependency(ReplaceServices = true)]
public class AbpTodoAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpTodoAppResource> _localizer;

    public AbpTodoAppBrandingProvider(IStringLocalizer<AbpTodoAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
