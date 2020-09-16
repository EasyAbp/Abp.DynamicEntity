using EasyAbp.Abp.DynamicEntity.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicEntity
{
    public abstract class DynamicEntityController : AbpController
    {
        protected DynamicEntityController()
        {
            LocalizationResource = typeof(DynamicEntityResource);
        }
    }
}
