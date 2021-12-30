using EasyAbp.Abp.DynamicEntity.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicEntity
{
    [Area(AbpDynamicEntityRemoteServiceConsts.ModuleName)]
    public abstract class DynamicEntityController : AbpController
    {
        protected DynamicEntityController()
        {
            LocalizationResource = typeof(DynamicEntityResource);
        }
    }
}
