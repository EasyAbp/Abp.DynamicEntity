using EasyAbp.Abp.DynamicEntity.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicEntity
{
    public abstract class DynamicEntityAppService : ApplicationService
    {
        protected DynamicEntityAppService()
        {
            LocalizationResource = typeof(DynamicEntityResource);
            ObjectMapperContext = typeof(DynamicEntityApplicationModule);
        }
    }
}
