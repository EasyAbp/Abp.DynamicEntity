using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace DynamicEntitySample.Web
{
    [Dependency(ReplaceServices = true)]
    public class DynamicEntitySampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DynamicEntitySample";
    }
}
