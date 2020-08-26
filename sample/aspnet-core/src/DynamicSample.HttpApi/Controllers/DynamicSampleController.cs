using DynamicSample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DynamicSample.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DynamicSampleController : AbpController
    {
        protected DynamicSampleController()
        {
            LocalizationResource = typeof(DynamicSampleResource);
        }
    }
}