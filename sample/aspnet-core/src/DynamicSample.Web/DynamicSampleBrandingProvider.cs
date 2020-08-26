using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace DynamicSample.Web
{
    [Dependency(ReplaceServices = true)]
    public class DynamicSampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DynamicSample";
    }
}
