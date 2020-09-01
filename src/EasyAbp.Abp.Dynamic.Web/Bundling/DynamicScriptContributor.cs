using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.Dynamic.Web.Bundling
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class DynamicScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddRange(new[]
            {
                "/libs/easy-abp/easy-abp-dynamic.js",
            });
        }
    }
}