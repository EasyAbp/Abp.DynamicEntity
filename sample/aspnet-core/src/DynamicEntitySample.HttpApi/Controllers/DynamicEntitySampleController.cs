using DynamicEntitySample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DynamicEntitySample.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DynamicEntitySampleController : AbpController
    {
        protected DynamicEntitySampleController()
        {
            LocalizationResource = typeof(DynamicEntitySampleResource);
        }
    }
}