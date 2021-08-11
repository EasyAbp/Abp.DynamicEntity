using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DynamicEntitySample.Web
{
    [Dependency(ReplaceServices = true)]
    public class DynamicEntitySampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DynamicEntitySample";
    }
}
