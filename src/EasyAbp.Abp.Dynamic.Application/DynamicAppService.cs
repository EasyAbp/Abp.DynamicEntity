using EasyAbp.Abp.Dynamic.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic
{
    public abstract class DynamicAppService : ApplicationService
    {
        protected DynamicAppService()
        {
            LocalizationResource = typeof(DynamicResource);
            ObjectMapperContext = typeof(DynamicApplicationModule);
        }
    }
}
