using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.Dynamic
{
    [Dependency(ReplaceServices = true)]
    public class DynamicBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Dynamic";
    }
}
