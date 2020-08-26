using EasyAbp.Abp.Dynamic.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.Dynamic
{
    public abstract class DynamicController : AbpController
    {
        protected DynamicController()
        {
            LocalizationResource = typeof(DynamicResource);
        }
    }
}
